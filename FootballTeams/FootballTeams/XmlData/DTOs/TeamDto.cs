using System.Collections.Generic;
using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlRoot(ElementName = "team", Namespace = "")]
    public class TeamDto
    {
        private HashSet<FootballManagerDto> managers;
        private HashSet<FootballPlayerDto> players;

        public TeamDto()
        {
            FootballManagers = new HashSet<FootballManagerDto>();
            FootballPlayers = new HashSet<FootballPlayerDto>();
        }

        [XmlAttribute(AttributeName = "team_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "alias")]
        public string Alias { get; set; }

        [XmlElement(ElementName = "established")]
        public int Established { get; set; }

        [XmlElement("stadium")]
        public StadiumDto Stadium { get; set; }

        [XmlElement("country")]
        public CountryDto Country { get; set; }

        [XmlElement(ElementName = "region")]
        public string Region { get; set; }

        [XmlElement("city")]
        public CityDto City { get; set; }

        [XmlElement(ElementName = "division")]
        public string Division { get; set; }

        [XmlElement("president")]
        public FootballPresidentDto FootballPresident { get; set; }

        [XmlArray(ElementName = "managers")]
        [XmlArrayItem(ElementName = "manager")]
        public HashSet<FootballManagerDto> FootballManagers
        {
            get { return this.managers; }
            set { this.managers = value; }
        }

        [XmlElement(ElementName = "trophies")]
        public int? Trophies { get; set; }

        [XmlElement(ElementName = "captain")]
        public string Captain { get; set; }

        [XmlElement(ElementName = "played_matches")]
        public int? PlayedMatches { get; set; }

        [XmlElement(ElementName = "won_matches")]
        public int? WonMatches { get; set; }

        [XmlElement(ElementName = "lost_matches")]
        public int? LostMatches { get; set; }

        [XmlArray(ElementName = "players")]
        [XmlArrayItem(ElementName = "player")]
        public HashSet<FootballPlayerDto> FootballPlayers
        {
            get { return this.players; }
            set { this.players = value; }
        }
    }
}
