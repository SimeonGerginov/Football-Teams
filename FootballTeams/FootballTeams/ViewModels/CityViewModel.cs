using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class CityViewModel
    {
        public IEnumerable<SelectListItem> CountriesSelectList { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }
    }
}
