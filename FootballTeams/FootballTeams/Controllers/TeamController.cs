using System;
using System.Collections.Generic;

using FootballTeams.Models;
using FootballTeams.Services.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace FootballTeams.Controllers
{
    public class TeamController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IXmlService xmlService;

        public TeamController(IAdminService adminService, IXmlService xmlService)
        {
            this.adminService = adminService ?? throw new ArgumentNullException();
            this.xmlService = xmlService ?? throw new ArgumentNullException();
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
                var players = this.adminService.GetAllPlayersOfTeam(team.Id);
                var managers = this.adminService.GetAllManagersOfTeam(team.Id);

                team.FootballPlayers = players;
                team.FootballManagers = managers;

                string fileName = $"XmlData/team-{team.Id}.xml";
                this.xmlService.WriteTeamToXml(fileName, team);
            }

            return this.RedirectToAction("Index", "Team");
        }
    }
}
