using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class ManagerViewModel
    {
        public IEnumerable<SelectListItem> TeamsSelectList { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името на мениджъра е задължително")]
        [StringLength(GlobalConstants.ManagerFirstNameMaxLength, 
            MinimumLength = GlobalConstants.ManagerFirstNameMinLength, 
            ErrorMessage = "Дължината на името трябва да бъде между {1} и {2} символа")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия на мениджъра е задължителна")]
        [StringLength(GlobalConstants.ManagerLastNameMaxLength, 
            MinimumLength = GlobalConstants.ManagerLastNameMinLength,
            ErrorMessage = "Дължината на фамилията трябва да бъде между {1} и {2} символа")]
        public string LastName { get; set; }

        [Display(Name = "Години")]
        [Required(ErrorMessage = "Годините на мениджъра са задължителни")]
        [Range(GlobalConstants.ManagerMinAge, GlobalConstants.ManagerMaxAge, 
            ErrorMessage = "Годините на мениджъра трябва да са в интервала между {1} и {2}")]
        public int Age { get; set; }

        [Display(Name = "Спечелени трофеи")]
        public int? TrophiesWon { get; set; }

        [Display(Name = "Отбор")]
        public int TeamId { get; set; }
    }
}
