using System.Xml.Serialization;

namespace FootballTeams.Models
{
    public class FootballManager
    {
        [XmlAttribute("manager_id")]
        public int Id { get; set; }

        [XmlElement("manager_first_name")]
        public string FirstName { get; set; }

        [XmlElement("manager_last_name")]
        public string LastName { get; set; }

        [XmlAttribute("manager_age")]
        public int Age { get; set; }

        [XmlElement("trophies_won")]
        public int? TrophiesWon { get; set; }

        [XmlAttribute("team_id")]
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
