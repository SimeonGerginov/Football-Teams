using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;

namespace FootballTeams.Models
{
    public class City
    {
        private ICollection<Team> teams;

        public City()
        {
            this.teams = new HashSet<Team>();
        }
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.CityNameMaxLength, MinimumLength = GlobalConstants.CityNameMinLength)]
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
