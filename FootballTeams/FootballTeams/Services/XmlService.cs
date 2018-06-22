using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using FootballTeams.Models;
using FootballTeams.Services.Contracts;
using FootballTeams.XmlData.DTOs;

namespace FootballTeams.Services
{
    public class XmlService : IXmlService
    {
        private readonly IDtoService dtoService;

        public XmlService(IDtoService dtoService)
        {
            this.dtoService = dtoService ?? throw new ArgumentNullException();
        }

        public void WriteTeamToXml(string fileName, Team team)
        {
            var fileStream = new FileStream(fileName, FileMode.Create);
            var settings = new XmlWriterSettings();
            var teamDto = this.dtoService.CreateTeamDto(team);

            settings.CloseOutput = true;
            settings.Indent = true;

            using (var writer = XmlWriter.Create(fileStream, settings))
            {
                var xmlSerializer = new XmlSerializer(typeof(TeamDto));
                var namespaces = new XmlSerializerNamespaces();

                namespaces.Add("", "");
                writer.WriteDocType("Team", null, "XmlData/Schema/FootballTeams.xsd", null);

                xmlSerializer.Serialize(writer, teamDto, namespaces);
            }
        }

        public Team ReadTeamFromXml(string fileName)
        {
            Team team;
            var settings = new XmlReaderSettings();
            var schemas = new XmlSchemaSet();

            var schemaUri = "../FootballTeams/XmlData/Schema/FootballTeams.xsd";

            schemas.Add(null, schemaUri);

            settings.DtdProcessing = DtdProcessing.Ignore;
            settings.ValidationType = ValidationType.Schema;
            settings.CloseInput = true;
            settings.Schemas = schemas;

            var fileStream = new FileStream(fileName, FileMode.Open);

            using (var reader = XmlReader.Create(fileStream, settings))
            {
                var xmlSerializer = new XmlSerializer(typeof(TeamDto));
                var teamDto = (TeamDto)xmlSerializer.Deserialize(reader);

                if (!fileName.Contains(teamDto.Id.ToString()))
                {
                    throw new InvalidOperationException("Invalid team!");
                }

                team = this.dtoService.CreateTeamFromDto(teamDto);
            }

            return team;
        }
    }
}
