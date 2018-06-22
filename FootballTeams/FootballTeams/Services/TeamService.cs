using System;
using System.Linq;

using FootballTeams.Models;
using FootballTeams.Repositories.Contracts;
using FootballTeams.Services.Contracts;

namespace FootballTeams.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IRepository<City> cityRepository;
        private readonly IRepository<Stadium> stadiumRepository;
        private readonly IRepository<FootballPresident> presidentRepository;
        private readonly IRepository<FootballManager> managerRepository;
        private readonly IRepository<FootballPlayer> playerRepository;
        private readonly IRepository<Team> teamRepository;

        public TeamService(IRepository<Country> countryRepository, IRepository<City> cityRepository, 
            IRepository<Stadium> stadiumRepository, IRepository<FootballPresident> presidentRepository, 
            IRepository<FootballManager> managerRepository, IRepository<FootballPlayer> playerRepository,
            IRepository<Team> teamRepository)
        {
            this.countryRepository = countryRepository ?? throw new ArgumentNullException();
            this.cityRepository = cityRepository ?? throw new ArgumentNullException();
            this.stadiumRepository = stadiumRepository ?? throw new ArgumentNullException();
            this.presidentRepository = presidentRepository ?? throw new ArgumentNullException();
            this.managerRepository = managerRepository ?? throw new ArgumentNullException();
            this.playerRepository = playerRepository ?? throw new ArgumentNullException();
            this.teamRepository = teamRepository ?? throw new ArgumentNullException();
        }

        public void AddTeam(Team team)
        {
            var teamExists = this.teamRepository
                .GetAllFiltered(t => t.Name == team.Name && t.Alias == team.Alias
                                                         && t.Established == team.Established)
                .Any();

            if (teamExists)
            {
                throw new InvalidOperationException("Team already exists!");
            }

            var countryId = team.CountryId ?? 0;
            var country = this.countryRepository.GetById(countryId);

            if (country == null)
            {
                this.countryRepository.Add(team.Country);
            }

            var cityId = team.CityId ?? 0;
            var city = this.cityRepository.GetById(cityId);

            if (city == null)
            {
                this.cityRepository.Add(team.City);
            }

            var stadiumId = team.StadiumId ?? 0;
            var stadium = this.stadiumRepository.GetById(stadiumId);

            if (stadium == null)
            {
                this.stadiumRepository.Add(team.Stadium);
            }

            var presidentId = team.FootballPresidentId ?? 0;
            var president = this.presidentRepository.GetById(presidentId);

            if (president == null)
            {
                this.presidentRepository.Add(team.FootballPresident);
            }

            foreach (var manager in team.FootballManagers)
            {
                var managerId = manager.Id;
                var foundManager = this.managerRepository.GetById(managerId);

                if (foundManager == null)
                {
                    this.managerRepository.Add(manager);
                }
            }

            foreach (var player in team.FootballPlayers)
            {
                var playerId = player.Id;
                var foundPlayer = this.playerRepository.GetById(playerId);

                if (foundPlayer == null)
                {
                    this.playerRepository.Add(player);
                }
            }

            this.teamRepository.Add(team);
        }
    }
}
