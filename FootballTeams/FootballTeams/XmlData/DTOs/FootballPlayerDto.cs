using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlType(TypeName = "player")]
    public class FootballPlayerDto
    {
        [XmlAttribute(AttributeName = "player_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "player_first_name")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "player_last_name")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "player_age")]
        public int Age { get; set; }

        [XmlAttribute(AttributeName = "position")]
        public string Position { get; set; }

        [XmlAttribute(AttributeName = "nationality")]
        public string Nationality { get; set; }

        [XmlElement(ElementName = "won_trophies")]
        public int? TrophiesWon { get; set; }

        [XmlAttribute(AttributeName = "team_id")]
        public int TeamId { get; set; }
    }
}
