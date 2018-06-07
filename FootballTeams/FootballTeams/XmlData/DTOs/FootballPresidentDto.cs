using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlRoot(ElementName = "president")]
    public class FootballPresidentDto
    {
        [XmlAttribute(AttributeName = "president_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "president_first_name")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "president_last_name")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "president_age")]
        public int Age { get; set; }
    }
}
