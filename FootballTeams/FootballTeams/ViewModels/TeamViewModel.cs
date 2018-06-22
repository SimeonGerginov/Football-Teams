using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class TeamViewModel
    {
        public IEnumerable<SelectListItem> StadiumsSelectList { get; set; }

        public IEnumerable<SelectListItem> CitieSelectList { get; set; }

        public IEnumerable<SelectListItem> CountriesSelectList { get; set; }

        public IEnumerable<SelectListItem> PresidentsSelectList { get; set; }

        [Display(Name = "Име на отбор")]
        [Required(ErrorMessage = "Името на отбора е задължително")]
        [StringLength(GlobalConstants.TeamNameMaxLength, MinimumLength = GlobalConstants.TeamNameMinLength, 
            ErrorMessage = "Името на отбора трябва да бъде между {1} и {2} символа")]
        public string Name { get; set; }

        [Display(Name = "Прякор на отбор")]
        [Required(ErrorMessage = "Прякора на отбора е задължителен")]
        [StringLength(GlobalConstants.TeamAliasMaxLength, MinimumLength = GlobalConstants.TeamAliasMinLength, 
            ErrorMessage = "Прякора на отбора трябва да бъде между {1} и {2} символа")]
        public string Alias { get; set; }

        [Display(Name = "Основан през")]
        [Required(ErrorMessage = "Кога е основан отбора е задължително поле")]
        [Range(GlobalConstants.TeamEstablishedMinYear, GlobalConstants.TeamEstablishedMaxYear, 
            ErrorMessage = "Отбора трябва да е основан в периода между {1} и {2} година")]
        public int Established { get; set; }

        [Display(Name = "Регион на отбора")]
        [Required(ErrorMessage = "Региона на отбора е задължителен")]
        [StringLength(GlobalConstants.TeamRegionMaxLength, MinimumLength = GlobalConstants.TeamRegionMinLength, 
            ErrorMessage = "Региона трябва да бъде между {1} и {2} символа")]
        public string Region { get; set; }

        [Display(Name = "Дивизия, в която играе отбора")]
        [Required(ErrorMessage = "Дивизията на отбора е задължителна")]
        [StringLength(GlobalConstants.TeamDivisionMaxLength, MinimumLength = GlobalConstants.TeamDivisionMinLength, 
            ErrorMessage = "Дивизията на отбора трябва да бъде между {1} и {2} символа")]
        public string Division { get; set; }

        [Display(Name = "Трофеи, спечелени от отбора")]
        public int? Trophies { get; set; }

        [Display(Name = "Име на капитана на отбора")]
        [Required(ErrorMessage = "Капитана е задължително поле")]
        [StringLength(GlobalConstants.TeamCaptainNameMaxLength, 
            MinimumLength = GlobalConstants.TeamCaptainNameMinLength, 
            ErrorMessage = "Името на капитана на отбора трябва да бъде между {1} и {2} символа")]
        public string Captain { get; set; }

        [Display(Name = "Изиграни мачове")]
        public int? PlayedMatches { get; set; }

        [Display(Name = "Спечелени мачове")]
        public int? WonMatches { get; set; }

        [Display(Name = "Загубени мачове")]
        public int? LostMatches { get; set; }

        [Display(Name = "Име на стадиона")]
        public string StadiumName { get; set; }

        [Display(Name = "Име на града")]
        public string CityName { get; set; }

        [Display(Name = "Име на държавата")]
        public string CountryName { get; set; }

        [Display(Name = "Име на президента")]
        public int PresidentId { get; set; }
    }
}
