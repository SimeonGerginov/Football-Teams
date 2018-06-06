using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class FootballPlayer
    {
        [XmlAttribute("player_id")]
        public int Id { get; set; }

        [XmlElement("player_first_name")]
        public string FirstName { get; set; }

        [XmlElement("player_last_name")]
        public string LastName { get; set; }

        [XmlElement("player_age")]
        public int Age { get; set; }

        [XmlAttribute("position")]
        public string Position { get; set; }

        [XmlAttribute("nationality")]
        public string Nationality { get; set; }

        [XmlElement("won_trophies")]
        public int? TrophiesWon { get; set; }

        [XmlAttribute("team_id")]
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
