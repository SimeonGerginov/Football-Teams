using System;

using FootballTeams.Models;
using FootballTeams.Repositories.Contracts;
using FootballTeams.Services.Contracts;
using FootballTeams.ViewModels;

namespace FootballTeams.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Country> countryRepository;

        public AdminService(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository ?? throw new ArgumentNullException();
        }

        public void AddCountryToDb(CountryViewModel countryVm)
        {
            var country = new Country()
            {
                Name = countryVm.Name
            };

            this.countryRepository.Add(country);
        }
    }
}
