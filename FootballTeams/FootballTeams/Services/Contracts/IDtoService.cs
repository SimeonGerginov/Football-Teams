using FootballTeams.Models;
using FootballTeams.XmlData.DTOs;

namespace FootballTeams.Services.Contracts
{
    public interface IDtoService
    {
        TeamDto CreateTeamDto(Team team);

        Team CreateTeamFromDto(TeamDto teamDto);
    }
}
