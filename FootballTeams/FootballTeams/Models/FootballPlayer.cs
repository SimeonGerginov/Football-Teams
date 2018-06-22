using System.ComponentModel.DataAnnotations;
using FootballTeams.Infrastructure;

namespace FootballTeams.Models
{
    public class FootballPlayer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.PlayerFirstNameMaxLength,
            MinimumLength = GlobalConstants.PlayerFirstNameMinLength)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.PlayerLastNameMaxLength,
            MinimumLength = GlobalConstants.PlayerLastNameMinLength)]
        public string LastName { get; set; }
        
        [Required]
        [Range(GlobalConstants.PlayerMinAge, GlobalConstants.PlayerMaxAge)]
        public int Age { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.PlayerPositionMaxLength, MinimumLength = GlobalConstants.PlayerPositionMinLength)]
        public string Position { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.PlayerNationalityMaxLength,
            MinimumLength = GlobalConstants.PlayerNationalityMinLength)]
        public string Nationality { get; set; }
        
        public int? TrophiesWon { get; set; }
        
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
