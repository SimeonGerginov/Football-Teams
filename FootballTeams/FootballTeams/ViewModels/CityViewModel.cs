using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class CityViewModel
    {
        public IEnumerable<SelectListItem> CountriesSelectList { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string CountryName { get; set; }
    }
}
