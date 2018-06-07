using System.Collections.Generic;

using FootballTeams.Models;
using FootballTeams.ViewModels;

namespace FootballTeams.Services.Contracts
{
    public interface IAdminService
    {
        void AddCountryToDb(CountryViewModel countryVm);

        void AddCityToDb(CityViewModel cityVm, string countryName);

        void AddStadiumToDb(StadiumViewModel stadiumVm);

        void AddPresidentToDb(PresidentViewModel presidentVm);

        void AddTeamToDb(TeamViewModel teamVm, string stadiumName, string cityName, string countryName,
            int presidentId);

        void AddManagerToDb(ManagerViewModel managerVm, int teamId);

        IEnumerable<Country> GetAllCountries();

        IEnumerable<Stadium> GetAllStadiums();

        IEnumerable<City> GetAllCities();

        IEnumerable<FootballPresident> GetAllPresidents();

        IEnumerable<Team> GetAllTeams();
    }
}
