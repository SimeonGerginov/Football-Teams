using System.ComponentModel.DataAnnotations;
using FootballTeams.Infrastructure;

namespace FootballTeams.ViewModels
{
    public class CountryViewModel
    {
        [Display(Name = "Име на държавата")]
        [Required(ErrorMessage = "Името на държавата е задължително")]
        [StringLength(GlobalConstants.CountryNameMaxLength, 
            MinimumLength = GlobalConstants.CountryNameMinLength, 
            ErrorMessage = "Името на държавата трябва да бъде между {1} и {2} символа")]
        public string Name { get; set; }
    }
}
