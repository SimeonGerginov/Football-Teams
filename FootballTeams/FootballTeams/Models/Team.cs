using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class Team
    {
        private ICollection<FootballManager> managers;
        private ICollection<FootballPlayer> players;

        public Team()
        {
            FootballManagers = new HashSet<FootballManager>();
            FootballPlayers = new HashSet<FootballPlayer>();
        }

        [XmlAttribute("team_id")]
        [Key]
        public int Id { get; set; }

        [XmlElement("name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("alias")]
        [Required]
        [MaxLength(30)]
        public string Alias { get; set; }

        [XmlElement("established")]
        [Required]
        public int Established { get; set; }

        [XmlElement("region")]
        [Required]
        [MaxLength(20)]
        public string Region { get; set; }

        [XmlElement("division")]
        [Required]
        [MaxLength(15)]
        public string Division { get; set; }

        [XmlElement("trophies")]
        public int? Trophies { get; set; }

        [XmlElement("captain")]
        [Required]
        [MaxLength(30)]
        public string Captain { get; set; }

        [XmlElement("played_matches")]
        public int? PlayedMatches { get; set; }

        [XmlElement("won_matches")]
        public int? WonMatches { get; set; }

        [XmlElement("lost_matches")]
        public int? LostMatches { get; set; }

        public int? StadiumId { get; set; }

        [XmlElement("stadium")]
        public Stadium Stadium { get; set; }

        public int? CityId { get; set; }

        [XmlElement("city")]
        public City City { get; set; }

        public int? CountryId { get; set; }

        [XmlElement("country")]
        public Country Country { get; set; }

        public int? FootballPresidentId { get; set; }

        [XmlElement("president")]
        public FootballPresident FootballPresident { get; set; }

        public ICollection<FootballManager> FootballManagers
        {
            get { return this.managers; }
            set { this.managers = value; }
        }

        public ICollection<FootballPlayer> FootballPlayers
        {
            get { return this.players; }
            set { this.players = value; }
        }
    }
}
