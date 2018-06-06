using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class FootballPlayer
    {
        [XmlAttribute("player_id")]
        [Key]
        public int Id { get; set; }

        [XmlElement("player_first_name")]
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [XmlElement("player_last_name")]
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [XmlElement("player_age")]
        [Required]
        public int Age { get; set; }

        [XmlAttribute("position")]
        [Required]
        [MaxLength(15)]
        public string Position { get; set; }

        [XmlAttribute("nationality")]
        [Required]
        [MaxLength(30)]
        public string Nationality { get; set; }

        [XmlElement("won_trophies")]
        public int? TrophiesWon { get; set; }

        [XmlAttribute("team_id")]
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
