﻿using System.ComponentModel.DataAnnotations;

namespace FootballTeams.ViewModels
{
    public class CountryViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
