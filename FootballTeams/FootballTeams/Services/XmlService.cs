using System;
using System.IO;
using System.Xml;
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

            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.XmlResolver = new XmlUrlResolver();
            settings.CloseInput = true;

            var fileStream = new FileStream(fileName, FileMode.Open);

            using (var reader = XmlReader.Create(fileStream, settings))
            {
                var xmlSerializer = new XmlSerializer(typeof(TeamDto));
                var teamDto = (TeamDto)xmlSerializer.Deserialize(reader);
                team = this.dtoService.CreateTeamFromDto(teamDto);
            }

            return team;
        }
    }
}
