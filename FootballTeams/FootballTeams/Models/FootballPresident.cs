using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;

namespace FootballTeams.Models
{
    public class FootballPresident
    {
        private ICollection<Team> teams;

        public FootballPresident()
        {
            this.teams = new HashSet<Team>();
        }
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.PresidentFirstNameMaxLength,
            MinimumLength = GlobalConstants.PresidentFirstNameMinLength)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.PresidentLastNameMaxLength,
            MinimumLength = GlobalConstants.PresidentLastNameMinLength)]
        public string LastName { get; set; }
        
        [Required]
        [Range(GlobalConstants.PresidentMinAge, GlobalConstants.PresidentMaxAge)]
        public int Age { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
