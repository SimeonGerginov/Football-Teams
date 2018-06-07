using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class TeamViewModel
    {
        public IEnumerable<SelectListItem> StadiumsSelectList { get; set; }

        public IEnumerable<SelectListItem> CitieSelectList { get; set; }

        public IEnumerable<SelectListItem> CountriesSelectList { get; set; }

        public IEnumerable<SelectListItem> PresidentsSelectList { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Alias { get; set; }

        [Required]
        public int Established { get; set; }

        [Required]
        [MaxLength(20)]
        public string Region { get; set; }

        [Required]
        [MaxLength(15)]
        public string Division { get; set; }

        public int? Trophies { get; set; }

        [Required]
        [MaxLength(30)]
        public string Captain { get; set; }

        public int? PlayedMatches { get; set; }

        public int? WonMatches { get; set; }

        public int? LostMatches { get; set; }

        public string StadiumName { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }

        public int PresidentId { get; set; }
    }
}
