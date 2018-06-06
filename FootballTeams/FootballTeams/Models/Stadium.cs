using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class Stadium
    {
        private ICollection<Team> teams;

        public Stadium()
        {
            this.teams = new HashSet<Team>();
        }

        [XmlAttribute("stadium_id")]
        [Key]
        public int Id { get; set; }

        [XmlElement("stadium_name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("capacity")]
        [Required]
        public int Capacity { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
