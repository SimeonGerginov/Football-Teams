using FootballTeams.Models;

namespace FootballTeams.Services.Contracts
{
    public interface IXmlService
    {
        void WriteTeamToXml(string fileName, Team team);

        // Team ReadFromXml(string fileName);
    }
}
