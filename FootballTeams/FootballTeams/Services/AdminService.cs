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
        private readonly IRepository<FootballPresident> presidentRepository;
        private readonly IRepository<Team> teamRepository;
        private readonly IRepository<FootballManager> managerRepository;
        private readonly IRepository<FootballPlayer> playerRepository;

        public AdminService(IRepository<Country> countryRepository, IRepository<City> cityRepository, 
            IRepository<Stadium> stadiumRepository, IRepository<FootballPresident> presidentRepository,
            IRepository<Team> teamRepository, IRepository<FootballManager> managerRepository,
            IRepository<FootballPlayer> playerRepository)
        {
            this.countryRepository = countryRepository ?? throw new ArgumentNullException();
            this.cityRepository = cityRepository ?? throw new ArgumentNullException();
            this.stadiumRepository = stadiumRepository ?? throw new ArgumentNullException();
            this.presidentRepository = presidentRepository ?? throw new ArgumentNullException();
            this.teamRepository = teamRepository ?? throw new ArgumentNullException();
            this.managerRepository = managerRepository ?? throw new ArgumentNullException();
            this.playerRepository = playerRepository ?? throw new ArgumentNullException();
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
                throw new ArgumentNullException();
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

        public void AddPresidentToDb(PresidentViewModel presidentVm)
        {
            var presidentExists = this.presidentRepository
                .GetAllFiltered(p => p.FirstName == presidentVm.FirstName && p.LastName == presidentVm.LastName &&
                                     p.Age == presidentVm.Age)
                .Any();

            if (presidentExists)
            {
                throw new InvalidOperationException();
            }

            var president = new FootballPresident()
            {
                FirstName = presidentVm.FirstName,
                LastName = presidentVm.LastName,
                Age = presidentVm.Age
            };

            this.presidentRepository.Add(president);
        }

        public void AddTeamToDb(TeamViewModel teamVm, string stadiumName, string cityName, string countryName, int presidentId)
        {
            var stadium = this.stadiumRepository
                .GetAllFiltered(s => s.Name == stadiumName)
                .FirstOrDefault();

            if (stadium == null)
            {
                throw new ArgumentNullException();
            }

            var country = this.countryRepository
                .GetAllFiltered(c => c.Name == countryName)
                .FirstOrDefault();

            if (country == null)
            {
                throw new ArgumentNullException();
            }

            var city = this.cityRepository
                .GetAllFiltered(c => c.Name == cityName && c.CountryId == country.Id)
                .FirstOrDefault();

            if (city == null)
            {
                throw new ArgumentNullException();
            }

            var president = this.presidentRepository
                .GetById(presidentId);

            if (president == null)
            {
                throw new ArgumentNullException();
            }

            var teamExists = this.teamRepository
                .GetAllFiltered(t => t.Name == teamVm.Name && t.Alias == teamVm.Alias
                                                           && t.Division == teamVm.Division)
                .Any();

            if (teamExists)
            {
                throw new InvalidOperationException();
            }

            var team = new Team()
            {
                Name = teamVm.Name,
                Alias = teamVm.Alias,
                Captain = teamVm.Captain,
                CityId = city.Id,
                CountryId = country.Id,
                Division = teamVm.Division,
                Established = teamVm.Established,
                Region = teamVm.Region,
                Trophies = teamVm.Trophies,
                PlayedMatches = teamVm.PlayedMatches,
                WonMatches = teamVm.WonMatches,
                LostMatches = teamVm.LostMatches,
                StadiumId = stadium.Id,
                FootballPresidentId = president.Id
            };

            this.teamRepository.Add(team);
        }

        public void AddManagerToDb(ManagerViewModel managerVm, int teamId)
        {
            var team = this.teamRepository
                .GetById(teamId);

            if (team == null)
            {
                throw new ArgumentNullException();
            }

            var managerExists = this.managerRepository
                .GetAllFiltered(m => m.FirstName == managerVm.FirstName && m.LastName == managerVm.LastName 
                                                                        && m.TeamId == team.Id)
                .Any();

            if (managerExists)
            {
                throw new InvalidOperationException();
            }

            var manager = new FootballManager()
            {
                FirstName = managerVm.FirstName,
                LastName = managerVm.LastName,
                Age = managerVm.Age,
                TeamId = team.Id,
                TrophiesWon = managerVm.TrophiesWon
            };

            this.managerRepository.Add(manager);
        }

        public void AddPlayerToDb(PlayerViewModel playerVm, int teamId)
        {
            var team = this.teamRepository
                .GetById(teamId);

            if (team == null)
            {
                throw new ArgumentNullException();
            }

            var playerExists = this.playerRepository
                .GetAllFiltered(p => p.FirstName == playerVm.FirstName && p.LastName == playerVm.LastName
                                                                       && p.TeamId == team.Id)
                .Any();

            if (playerExists)
            {
                throw new InvalidOperationException();
            }

            var player = new FootballPlayer()
            {
                FirstName = playerVm.FirstName,
                LastName = playerVm.LastName,
                Age = playerVm.Age,
                TrophiesWon = playerVm.TrophiesWon,
                Nationality = playerVm.Nationality,
                Position = playerVm.Position,
                TeamId = team.Id
            };

            this.playerRepository.Add(player);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.countryRepository.GetAllOrdered(c => c.Name);
        }

        public IEnumerable<Stadium> GetAllStadiums()
        {
            return this.stadiumRepository.GetAllOrdered(s => s.Name);
        }

        public IEnumerable<City> GetAllCities()
        {
            return this.cityRepository.GetAllOrdered(c => c.Name);
        }

        public IEnumerable<FootballPresident> GetAllPresidents()
        {
            return this.presidentRepository.GetAllOrdered(p => p.FirstName);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return this.teamRepository.GetAllOrdered(t => t.Name);
        }
    }
}
