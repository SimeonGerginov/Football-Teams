using System.Collections.Generic;
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
        public int Id { get; set; }

        [XmlElement("stadium_name")]
        public string Name { get; set; }

        [XmlElement("capacity")]
        public int Capacity { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
