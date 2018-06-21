using System.Collections.Generic;

using FootballTeams.Models;
using FootballTeams.Services.Contracts;
using FootballTeams.XmlData.DTOs;

namespace FootballTeams.Services
{
    public class DtoService : IDtoService
    {
        public TeamDto CreateTeamDto(Team team)
        {
            var cityDto = this.CreateCityDto(team.City);
            var countryDto = this.CreateCountryDto(team.Country);
            var presidentDto = this.CreatePresidentDto(team.FootballPresident);
            var managersDto = this.CreateManagerDtoCollection(team.FootballManagers);
            var playersDto = this.CreatePlayerDtoCollection(team.FootballPlayers);

            var teamDto = new TeamDto()
            {
                Name = team.Name,
                Alias = team.Alias,
                City = cityDto,
                Captain = team.Captain,
                Country = countryDto,
                Division = team.Division,
                Established = team.Established,
                FootballPresident = presidentDto,
                FootballManagers = managersDto,
                FootballPlayers = playersDto
            };

            return teamDto;
        }

        private CityDto CreateCityDto(City city)
        {
            var cityDto = new CityDto()
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = (int)city.CountryId
            };

            return cityDto;
        }

        private CountryDto CreateCountryDto(Country country)
        {
            var countryDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };

            return countryDto;
        }

        private FootballPresidentDto CreatePresidentDto(FootballPresident president)
        {
            var presidentDto = new FootballPresidentDto()
            {
                Id = president.Id,
                FirstName = president.FirstName,
                LastName = president.LastName,
                Age = president.Age
            };

            return presidentDto;
        }

        private FootballManagerDto CreateManagerDto(FootballManager manager)
        {
            var managerDto = new FootballManagerDto()
            {
                Id = manager.Id,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Age = manager.Age,
                TeamId = (int)manager.TeamId,
                TrophiesWon = manager.TrophiesWon
            };

            return managerDto;
        }

        private HashSet<FootballManagerDto> CreateManagerDtoCollection(ICollection<FootballManager> managers)
        {
            var managersDto = new HashSet<FootballManagerDto>();

            foreach (var manager in managers)
            {
                var managerDto = this.CreateManagerDto(manager);
                managersDto.Add(managerDto);
            }

            return managersDto;
        }

        private FootballPlayerDto CreatePlayerDto(FootballPlayer player)
        {
            var playerDto = new FootballPlayerDto()
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Age = player.Age,
                Nationality = player.Nationality,
                Position = player.Position,
                TrophiesWon = player.TrophiesWon,
                TeamId = (int)player.TeamId
            };

            return playerDto;
        }

        private HashSet<FootballPlayerDto> CreatePlayerDtoCollection(ICollection<FootballPlayer> players)
        {
            var playersDto = new HashSet<FootballPlayerDto>();

            foreach (var player in players)
            {
                var playerDto = this.CreatePlayerDto(player);
                playersDto.Add(playerDto);
            }

            return playersDto;
        }
    }
}
