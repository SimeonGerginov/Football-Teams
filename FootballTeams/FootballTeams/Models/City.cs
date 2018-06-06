using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class City
    {
        private ICollection<Team> teams;

        public City()
        {
            this.teams = new HashSet<Team>();
        }

        [XmlAttribute("city_id")]
        [Key]
        public int Id { get; set; }
        
        [XmlElement("city_name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlAttribute("country_id")]
        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
