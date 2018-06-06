using FootballTeams.ViewModels;

namespace FootballTeams.Services.Contracts
{
    public interface IAdminService
    {
        void AddCountryToDb(CountryViewModel countryVm);
    }
}
