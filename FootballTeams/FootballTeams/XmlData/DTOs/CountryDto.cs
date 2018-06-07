using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlRoot(ElementName = "country")]
    public class CountryDto
    {
        [XmlAttribute(AttributeName = "country_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "country_name")]
        public string Name { get; set; }
    }
}
