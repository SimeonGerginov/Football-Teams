using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class CityViewModel
    {
        public IEnumerable<SelectListItem> CountriesSelectList { get; set; }

        [Display(Name = "Име на града")]
        [Required(ErrorMessage = "Името на града е задължително")]
        [StringLength(GlobalConstants.CityNameMaxLength, 
            MinimumLength = GlobalConstants.CityNameMinLength, 
            ErrorMessage = "Името на града трябва да бъде между {1} и {2} символа")]
        public string Name { get; set; }

        [Display(Name = "Име на държавата")]
        [Required]
        public string CountryName { get; set; }
    }
}
