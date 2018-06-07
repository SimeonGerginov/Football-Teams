using System;
using System.Collections.Generic;
using System.Linq;

using FootballTeams.Models;
using FootballTeams.Repositories.Contracts;
using FootballTeams.Services.Contracts;
using FootballTeams.ViewModels;

namespace FootballTeams.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IRepository<City> cityRepository;
        private readonly IRepository<Stadium> stadiumRepository;

        public AdminService(IRepository<Country> countryRepository, IRepository<City> cityRepository, 
            IRepository<Stadium> stadiumRepository)
        {
            this.countryRepository = countryRepository ?? throw new ArgumentNullException();
            this.cityRepository = cityRepository ?? throw new ArgumentNullException();
            this.stadiumRepository = stadiumRepository ?? throw new ArgumentNullException();
        }

        public void AddCountryToDb(CountryViewModel countryVm)
        {
            var countryExists = this.countryRepository
                .GetAllFiltered(c => c.Name == countryVm.Name)
                .Any();

            if (countryExists)
            {
                throw new InvalidOperationException();
            }

            var country = new Country()
            {
                Name = countryVm.Name
            };

            this.countryRepository.Add(country);
        }

        public void AddCityToDb(CityViewModel cityVm, string countryName)
        {
            var country = this.countryRepository
                .GetAllFiltered(c => c.Name == countryName)
                .FirstOrDefault();

            if (country == null)
            {
                throw new InvalidOperationException();
            }

            var cityExists = this.cityRepository
                .GetAllFiltered(c => c.Name == cityVm.Name && c.CountryId == country.Id)
                .Any();

            if (cityExists)
            {
                throw new InvalidOperationException();
            }

            var city = new City()
            {
                Name = cityVm.Name,
                CountryId = country.Id
            };

            this.cityRepository.Add(city);
        }

        public void AddStadiumToDb(StadiumViewModel stadiumVm)
        {
            var stadiumExists = this.stadiumRepository
                .GetAllFiltered(s => s.Name == stadiumVm.Name && s.Capacity == stadiumVm.Capacity)
                .Any();

            if (stadiumExists)
            {
                throw new InvalidOperationException();
            }

            var stadium = new Stadium()
            {
                Name = stadiumVm.Name,
                Capacity = stadiumVm.Capacity
            };

            this.stadiumRepository.Add(stadium);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.countryRepository.GetAll();
        }
    }
}
