using System.Collections.Generic;

using FootballTeams.Models;
using FootballTeams.ViewModels;

namespace FootballTeams.Services.Contracts
{
    public interface ITeamService
    {
        void AddTeam(Team team);

        TeamDetailsViewModel GetTeamDetails(int teamId);

        IEnumerable<AllTeamsViewModel> GetAllTeams();
    }
}
