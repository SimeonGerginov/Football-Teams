using System;
using System.Linq;

using FootballTeams.Models;
using FootballTeams.Repositories.Contracts;
using FootballTeams.Services.Contracts;

namespace FootballTeams.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> teamRepository;

        public TeamService(IRepository<Team> teamRepository)
        {
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

            this.teamRepository.Add(team);
        }
    }
}
