using System.Collections.Generic;

namespace FootballTeams.Models
{
    public class FootballPresident
    {
        private ICollection<Team> teams;

        public FootballPresident()
        {
            this.teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
