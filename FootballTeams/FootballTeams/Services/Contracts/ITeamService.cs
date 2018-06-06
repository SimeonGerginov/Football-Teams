using FootballTeams.Models;

namespace FootballTeams.Services.Contracts
{
    public interface ITeamService
    {
        void WriteTeamToXml(string fileName, Team team);
    }
}
