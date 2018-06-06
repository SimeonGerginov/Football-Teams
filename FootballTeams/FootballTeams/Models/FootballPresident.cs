using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class FootballPresident
    {
        private ICollection<Team> teams;

        public FootballPresident()
        {
            this.teams = new HashSet<Team>();
        }

        [XmlAttribute("president_id")]
        [Key]
        public int Id { get; set; }

        [XmlElement("president_first_name")]
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [XmlElement("president_last_name")]
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [XmlAttribute("president_age")]
        [Required]
        public int Age { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
