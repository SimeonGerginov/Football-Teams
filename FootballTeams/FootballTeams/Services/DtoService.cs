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
            var stadiumDto = this.CreateStadiumDto(team.Stadium);
            var cityDto = this.CreateCityDto(team.City);
            var countryDto = this.CreateCountryDto(team.Country);
            var presidentDto = this.CreatePresidentDto(team.FootballPresident);
            var managersDto = this.CreateManagerDtoCollection(team.FootballManagers);
            var playersDto = this.CreatePlayerDtoCollection(team.FootballPlayers);

            var teamDto = new TeamDto()
            {
                Name = team.Name,
                Alias = team.Alias,
                Established = team.Established,
                Region = team.Region,
                Division = team.Division,
                Trophies = team.Trophies,
                PlayedMatches = team.PlayedMatches,
                WonMatches = team.WonMatches,
                LostMatches = team.LostMatches,
                Stadium = stadiumDto,
                City = cityDto,
                Captain = team.Captain,
                Country = countryDto,
                FootballPresident = presidentDto,
                FootballManagers = managersDto,
                FootballPlayers = playersDto
            };

            return teamDto;
        }

        public Team CreateTeamFromDto(TeamDto teamDto)
        {
            var stadium = this.CreateStadiumFromDto(teamDto.Stadium);
            var country = this.CreateCountryFromDto(teamDto.Country);
            var city = this.CreateCityFromDto(teamDto.City);
            var president = this.CreatePresidentFromDto(teamDto.FootballPresident);
            var managers = this.CreateManagerCollection(teamDto.FootballManagers);
            var players = this.CreatePlayerCollection(teamDto.FootballPlayers);

            var team = new Team()
            {
                Name = teamDto.Name,
                Alias = teamDto.Alias,
                Established = teamDto.Established,
                Region = teamDto.Region,
                Division = teamDto.Division,
                Trophies = teamDto.Trophies,
                Captain = teamDto.Captain,
                PlayedMatches = teamDto.PlayedMatches,
                WonMatches = teamDto.WonMatches,
                LostMatches = teamDto.LostMatches,
                StadiumId = teamDto.Stadium.Id,
                Stadium = stadium,
                CountryId = teamDto.Country.Id,
                Country = country,
                CityId = teamDto.City.Id,
                City = city,
                FootballPresidentId = teamDto.FootballPresident.Id,
                FootballPresident = president,
                FootballManagers = managers,
                FootballPlayers = players
            };

            return team;
        }

        private StadiumDto CreateStadiumDto(Stadium stadium)
        {
            var stadiumDto = new StadiumDto()
            {
                Id = stadium.Id,
                Name = stadium.Name,
                Capacity = stadium.Capacity
            };

            return stadiumDto;
        }

        private Stadium CreateStadiumFromDto(StadiumDto stadiumDto)
        {
            var stadium = new Stadium()
            {
                Name = stadiumDto.Name,
                Capacity = stadiumDto.Capacity
            };

            return stadium;
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

        private City CreateCityFromDto(CityDto cityDto)
        {
            var city = new City()
            {
                Name = cityDto.Name,
                CountryId = cityDto.CountryId
            };

            return city;
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

        private Country CreateCountryFromDto(CountryDto countryDto)
        {
            var country = new Country()
            {
                Name = countryDto.Name
            };

            return country;
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

        private FootballPresident CreatePresidentFromDto(FootballPresidentDto presidentDto)
        {
            var president = new FootballPresident()
            {
                FirstName = presidentDto.FirstName,
                LastName = presidentDto.LastName,
                Age = presidentDto.Age
            };

            return president;
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

        private FootballManager CreateManagerFromDto(FootballManagerDto managerDto)
        {
            var manager = new FootballManager()
            {
                FirstName = managerDto.FirstName,
                LastName = managerDto.LastName,
                Age = managerDto.Age,
                TeamId = managerDto.TeamId,
                TrophiesWon = managerDto.TrophiesWon
            };

            return manager;
        }

        private ICollection<FootballManager> CreateManagerCollection(HashSet<FootballManagerDto> managersDtos)
        {
            var managers = new HashSet<FootballManager>();

            foreach (var managerDto in managersDtos)
            {
                var manager = this.CreateManagerFromDto(managerDto);
                managers.Add(manager);
            }

            return managers;
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

        private FootballPlayer CreatePlayerFromDto(FootballPlayerDto playerDto)
        {
            var player = new FootballPlayer()
            {
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                Age = playerDto.Age,
                Nationality = playerDto.Nationality,
                Position = playerDto.Position,
                TrophiesWon = playerDto.TrophiesWon,
                TeamId = playerDto.TeamId
            };

            return player;
        }

        private ICollection<FootballPlayer> CreatePlayerCollection(HashSet<FootballPlayerDto> playersDtos)
        {
            var players = new HashSet<FootballPlayer>();

            foreach (var playerDto in playersDtos)
            {
                var player = this.CreatePlayerFromDto(playerDto);
                players.Add(player);
            }

            return players;
        }
    }
}
