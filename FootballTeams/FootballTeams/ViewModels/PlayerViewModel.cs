using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class PlayerViewModel
    {
        public IEnumerable<SelectListItem> TeamsSelectList { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(15)]
        public string Position { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nationality { get; set; }

        public int? TrophiesWon { get; set; }

        public int TeamId { get; set; }
    }
}
