using System.ComponentModel.DataAnnotations;
using FootballTeams.Infrastructure;

namespace FootballTeams.ViewModels
{
    public class PresidentViewModel
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името на президента е задължително")]
        [StringLength(GlobalConstants.PresidentFirstNameMaxLength,
            MinimumLength = GlobalConstants.PresidentFirstNameMinLength,
            ErrorMessage = "Дължината на името трябва да бъде между {1} и {2} символа")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия на президента е задължителна")]
        [StringLength(GlobalConstants.PresidentLastNameMaxLength,
            MinimumLength = GlobalConstants.PresidentLastNameMinLength,
            ErrorMessage = "Дължината на фамилията трябва да бъде между {1} и {2} символа")]
        public string LastName { get; set; }

        [Display(Name = "Години")]
        [Required(ErrorMessage = "Годините на президента са задължителни")]
        [Range(GlobalConstants.PresidentMinAge, GlobalConstants.PresidentMaxAge,
            ErrorMessage = "Годините на президента трябва да са в интервала между {1} и {2}")]
        public int Age { get; set; }
    }
}
