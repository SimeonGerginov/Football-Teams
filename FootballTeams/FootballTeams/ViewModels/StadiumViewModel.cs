using System.ComponentModel.DataAnnotations;
using FootballTeams.Infrastructure;

namespace FootballTeams.ViewModels
{
    public class StadiumViewModel
    {
        [Display(Name = "Име на стадион")]
        [Required(ErrorMessage = "Името на стадиона е задължително")]
        [StringLength(GlobalConstants.StadiumNameMaxLength, MinimumLength = GlobalConstants.StadiumNameMinLength, 
            ErrorMessage = "Името на стадиона трябва да бъде между {1} и {0} символа")]
        public string Name { get; set; }

        [Display(Name = "Капацитет")]
        [Required(ErrorMessage = "Капацитета на стадиона е задължителен")]
        [Range(GlobalConstants.MinCapacity, GlobalConstants.MaxCapacity, 
            ErrorMessage = "Капацитета на стадиона трябва да бъде между {0} и {1}")]
        public int Capacity { get; set; }
    }
}
