﻿using FootballTeams.Models;

namespace FootballTeams.Services.Contracts
{
    public interface ITeamService
    {
        void AddTeam(Team team);
    }
}