using System;
using System.IO;

using FootballTeams.Infrastructure.Filters;
using FootballTeams.Models;
using FootballTeams.Services.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace FootballTeams.Controllers
{
    public class TeamController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IXmlService xmlService;
        private readonly ITeamService teamService;

        public TeamController(IAdminService adminService, IXmlService xmlService, ITeamService teamService)
        {
            this.adminService = adminService ?? throw new ArgumentNullException();
            this.xmlService = xmlService ?? throw new ArgumentNullException();
            this.teamService = teamService ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportData()
        {
            var teams = this.adminService.GetAllTeamsWithIncludedEntities();

            foreach (var team in teams)
            {
                string fileName = $"XmlData/team-{team.Id}.xml";

                if (System.IO.File.Exists(fileName))
                {
                    continue;
                }

                var players = this.adminService.GetAllPlayersOfTeam(team.Id);
                var managers = this.adminService.GetAllManagersOfTeam(team.Id);

                team.FootballPlayers = players;
                team.FootballManagers = managers;
                this.xmlService.WriteTeamToXml(fileName, team);
            }

            return this.RedirectToAction("Index", "Team");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult ImportData()
        {
            var fileNames = Directory.GetFiles("XmlData", "*.xml");

            foreach (var xmlFileName in fileNames)
            {
                Team team = this.xmlService.ReadTeamFromXml(xmlFileName);
                this.teamService.AddTeam(team);
            }

            return this.RedirectToAction("Index", "Team");
        }
    }
}
