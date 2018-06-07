using System.Xml.Serialization;

namespace FootballTeams.XmlData.DTOs
{
    [XmlRoot(ElementName = "city")]
    public class CityDto
    {
        public CityDto()
        {
        }

        [XmlAttribute(AttributeName = "city_id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "city_name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "country_id")]
        public int? CountryId { get; set; }
    }
}
