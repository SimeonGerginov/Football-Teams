using System.Collections.Generic;

namespace FootballTeams.Models
{
    public class City
    {
        private ICollection<Team> teams;

        public City()
        {
            this.teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
