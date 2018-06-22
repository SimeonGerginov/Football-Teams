using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;

namespace FootballTeams.Models
{
    public class Country
    {
        private ICollection<City> cities;
        private ICollection<Team> teams;

        public Country()
        {
            this.cities = new HashSet<City>();
            this.teams = new HashSet<Team>();
        }
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.CountryNameMaxLength, MinimumLength = GlobalConstants.CountryNameMinLength)]
        public string Name { get; set; }

        public ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
