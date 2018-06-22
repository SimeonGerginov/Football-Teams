using System.ComponentModel.DataAnnotations;
using FootballTeams.Infrastructure;

namespace FootballTeams.Models
{
    public class FootballManager
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.ManagerFirstNameMaxLength, 
            MinimumLength = GlobalConstants.ManagerFirstNameMinLength)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.ManagerLastNameMaxLength,
            MinimumLength = GlobalConstants.ManagerLastNameMinLength)]
        public string LastName { get; set; }
        
        [Required]
        [Range(GlobalConstants.ManagerMinAge, GlobalConstants.ManagerMaxAge)]
        public int Age { get; set; }
        
        public int? TrophiesWon { get; set; }
        
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
