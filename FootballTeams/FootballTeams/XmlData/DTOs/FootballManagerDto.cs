using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlRoot(ElementName = "manager")]
    public class FootballManagerDto
    {
        [XmlAttribute(AttributeName = "manager_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "manager_first_name")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "manager_last_name")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "manager_age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "trophies_won")]
        public int? TrophiesWon { get; set; }

        [XmlAttribute(AttributeName = "team_id")]
        public int TeamId { get; set; }
    }
}
