using System;
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
            if (adminService == null)
            {
                throw new ArgumentNullException();
            }

            this.adminService = adminService;
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCountry(CountryViewModel countryVm)
        {
            if (this.ModelState.IsValid)
            {
                this.adminService.AddCountryToDb(countryVm);

                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                return this.View(countryVm);
            }
        }
    }
}
