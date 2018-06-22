using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class PlayerViewModel
    {
        public IEnumerable<SelectListItem> TeamsSelectList { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името на играча е задължително")]
        [StringLength(GlobalConstants.PlayerFirstNameMaxLength,
            MinimumLength = GlobalConstants.PlayerFirstNameMinLength,
            ErrorMessage = "Дължината на името трябва да бъде между {1} и {2} символа")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия на играча е задължителна")]
        [StringLength(GlobalConstants.PlayerLastNameMaxLength,
            MinimumLength = GlobalConstants.PlayerLastNameMinLength,
            ErrorMessage = "Дължината на фамилията трябва да бъде между {1} и {2} символа")]
        public string LastName { get; set; }

        [Display(Name = "Години")]
        [Required(ErrorMessage = "Годините на играча са задължителни")]
        [Range(GlobalConstants.PlayerMinAge, GlobalConstants.PlayerMaxAge,
            ErrorMessage = "Годините на играча трябва да са в интервала между {1} и {2}")]
        public int Age { get; set; }

        [Display(Name = "Позиция")]
        [Required(ErrorMessage = "Позицията на играча е задължителна")]
        [StringLength(GlobalConstants.PlayerPositionMaxLength, MinimumLength = GlobalConstants.PlayerPositionMinLength,
            ErrorMessage = "Позицията на играча трябва да бъде между {1} и {2} символа")]
        public string Position { get; set; }

        [Display(Name = "Националност")]
        [Required(ErrorMessage = "Националността на играча е задължителна")]
        [StringLength(GlobalConstants.PlayerNationalityMaxLength, 
            MinimumLength = GlobalConstants.PlayerNationalityMinLength, 
            ErrorMessage = "Националността на играча трябва да бъде между {1} и {2} символа")]
        public string Nationality { get; set; }

        [Display(Name = "Спечелени трофеи")]
        public int? TrophiesWon { get; set; }

        [Display(Name = "Отбор")]
        public int TeamId { get; set; }
    }
}
