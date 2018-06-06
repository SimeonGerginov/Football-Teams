using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class Country
    {
        private ICollection<City> cities;
        private ICollection<Team> teams;

        public Country()
        {
            this.cities = new HashSet<City>();
            this.teams = new HashSet<Team>();
        }

        [XmlAttribute("country_id")]
        [Key]
        public int Id { get; set; }

        [XmlElement("country_name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
