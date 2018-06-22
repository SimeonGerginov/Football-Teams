using System;
using System.IO;

using FootballTeams.Infrastructure.Filters;
using FootballTeams.Models;
using FootballTeams.Services.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootballTeams.Controllers
{
    public class TeamController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IXmlService xmlService;
        private readonly ITeamService teamService;
        private readonly ILogger logger;

        public TeamController(IAdminService adminService, IXmlService xmlService, ITeamService teamService,
            ILogger<TeamController> logger)
        {
            this.adminService = adminService ?? throw new ArgumentNullException();
            this.xmlService = xmlService ?? throw new ArgumentNullException();
            this.teamService = teamService ?? throw new ArgumentNullException();
            this.logger = logger ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var teams = this.teamService.GetAllTeams();

            return this.View(teams);
        }

        [HttpGet]
        public IActionResult TeamDetails(int teamId)
        {
            var teamDetails = this.teamService.GetTeamDetails(teamId);

            return this.View(teamDetails);
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

                try
                {
                    this.xmlService.WriteTeamToXml(fileName, team);
                    this.logger.LogInformation(null, "Team {} exported successfully", team.Id);
                }
                catch (Exception e)
                {
                    this.logger.LogWarning(e, "Could not export team to {}: {}",
                        fileName, e.InnerException?.Message);
                }
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(SaveChangesFilter))]
        public IActionResult ImportData()
        {
            var fileNames = Directory.GetFiles("XmlData", "*.xml");

            foreach (var xmlFileName in fileNames)
            {
                try
                {
                    Team team = this.xmlService.ReadTeamFromXml(xmlFileName);
                    this.teamService.AddTeam(team);

                    this.logger.LogInformation(null, "Team {0} imported to db successfully", team.Name);
                }
                catch (InvalidOperationException e)
                {
                    this.logger.LogWarning(e, "Could not import team from {}: {}", 
                        xmlFileName, e.InnerException?.Message);
                }
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
