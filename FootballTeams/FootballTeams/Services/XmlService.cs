using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using FootballTeams.Models;
using FootballTeams.Services.Contracts;

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
                var xmlSerializer = new XmlSerializer(typeof(Team));
                var namespaces = new XmlSerializerNamespaces();

                namespaces.Add("", "");
                writer.WriteDocType("Team", null, "XmlData/Schema/FootballTeams.xsd", null);

                xmlSerializer.Serialize(writer, teamDto, namespaces);
            }
        }
    }
}
