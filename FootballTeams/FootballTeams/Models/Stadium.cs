using System.Collections.Generic;

namespace FootballTeams.Models
{
    public class Stadium
    {
        private ICollection<Team> teams;

        public Stadium()
        {
            this.teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
