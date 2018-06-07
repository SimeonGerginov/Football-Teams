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
    }
}
