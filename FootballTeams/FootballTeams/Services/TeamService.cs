using System;
using System.Collections.Generic;
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
                throw new InvalidOperationException("Country does not exist!");
            }

            var cityId = team.CityId ?? 0;
            var city = this.cityRepository.GetById(cityId);

            if (city == null)
            {
                throw new InvalidOperationException("City does not exist!");
            }

            var stadiumId = team.StadiumId ?? 0;
            var stadium = this.stadiumRepository.GetById(stadiumId);

            if (stadium == null)
            {
                throw new InvalidOperationException("Stadium does not exist!");
            }

            var presidentId = team.FootballPresidentId ?? 0;
            var president = this.presidentRepository.GetById(presidentId);

            if (president == null)
            {
                throw new InvalidOperationException("President does not exist!");
            }

            var managersToRemove = new HashSet<FootballManager>();

            foreach (var manager in team.FootballManagers)
            {
                var foundManager = this.managerRepository.GetById(manager.Id);

                if (foundManager == null)
                {
                    continue;
                }

                if (foundManager.FirstName == manager.FirstName && foundManager.LastName == manager.LastName)
                {
                    if (foundManager.TeamId != manager.TeamId)
                    {
                        foundManager.TeamId = manager.TeamId;
                        this.managerRepository.Update(foundManager);
                    }
                    else
                    {
                        managersToRemove.Add(manager);
                    }
                }
            }

            foreach (var managerToRemove in managersToRemove)
            {
                team.FootballManagers.Remove(managerToRemove);
            }

            var playersToRemove = new HashSet<FootballPlayer>();

            foreach (var player in team.FootballPlayers)
            {
                var foundPlayer = this.playerRepository.GetById(player.Id);

                if (foundPlayer == null)
                {
                    continue;
                }

                if (foundPlayer.FirstName == player.FirstName && foundPlayer.LastName == player.LastName)
                {
                    if (foundPlayer.TeamId != player.TeamId)
                    {
                        foundPlayer.TeamId = player.TeamId;
                        this.playerRepository.Update(foundPlayer);
                    }
                    else
                    {
                        playersToRemove.Add(player);
                    }
                }
            }

            foreach (var playerToRemove in playersToRemove)
            {
                team.FootballPlayers.Remove(playerToRemove);
            }

            this.teamRepository.Add(team);
        }
    }
}
