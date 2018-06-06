﻿using System.Collections.Generic;

using FootballTeams.Models;
using FootballTeams.ViewModels;

namespace FootballTeams.Services.Contracts
{
    public interface IAdminService
    {
        void AddCountryToDb(CountryViewModel countryVm);

        void AddCityToDb(CityViewModel cityVm, string countryName);

        IEnumerable<Country> GetAllCountries();
    }
}
