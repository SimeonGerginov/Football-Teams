using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlRoot(ElementName = "stadium")]
    public class StadiumDto
    {
        [XmlAttribute(AttributeName = "stadium_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "stadium_name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "capacity")]
        public int Capacity { get; set; }
    }
}
