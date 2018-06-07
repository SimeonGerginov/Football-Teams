using System;
using System.Linq;

using FootballTeams.Infrastructure.Filters;
using FootballTeams.Services.Contracts;
using FootballTeams.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult AddCountry(CountryViewModel countryVm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(countryVm);
            }

            this.adminService.AddCountryToDb(countryVm);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddCity()
        {
            var countriesSelectList = this.adminService
                .GetAllCountries()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Name });

            var cityVm = new CityViewModel()
            {
                CountriesSelectList = countriesSelectList
            };

            return this.View(cityVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult AddCity(CityViewModel cityVm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(cityVm);
            }

            this.adminService.AddCityToDb(cityVm, cityVm.CountryName);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddStadium()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult AddStadium(StadiumViewModel stadiumVm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(stadiumVm);
            }

            this.adminService.AddStadiumToDb(stadiumVm);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddPresident()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult AddPresident(PresidentViewModel presidentVm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(presidentVm);
            }

            this.adminService.AddPresidentToDb(presidentVm);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            var stadiumsSelectList = this.adminService
                .GetAllStadiums()
                .Select(s => new SelectListItem() { Text = s.Name, Value = s.Name });

            var citiesSelectList = this.adminService
                .GetAllCities()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Name });

            var countriesSelectList = this.adminService
                .GetAllCountries()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Name });

            var presidentsSelectList = this.adminService
                .GetAllPresidents()
                .Select(p => new SelectListItem() { Text = $"{p.FirstName} {p.LastName}", Value = p.Id.ToString() });

            var teamViewModel = new TeamViewModel()
            {
                StadiumsSelectList = stadiumsSelectList,
                CitieSelectList = citiesSelectList,
                CountriesSelectList = countriesSelectList,
                PresidentsSelectList = presidentsSelectList
            };

            return this.View(teamViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult AddTeam(TeamViewModel teamVm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(teamVm);
            }

            var stadiumName = teamVm.StadiumName;
            var cityName = teamVm.CityName;
            var countryName = teamVm.CountryName;
            var presidentId = teamVm.PresidentId;

            this.adminService.AddTeamToDb(teamVm, stadiumName, cityName, countryName, presidentId);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
