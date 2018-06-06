using System;

using FootballTeams.Infrastructure.Filters;
using FootballTeams.Services.Contracts;
using FootballTeams.ViewModels;

using Microsoft.AspNetCore.Mvc;

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
    }
}
