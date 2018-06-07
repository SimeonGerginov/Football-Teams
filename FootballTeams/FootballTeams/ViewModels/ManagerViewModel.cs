using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballTeams.ViewModels
{
    public class ManagerViewModel
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

        public int? TrophiesWon { get; set; }

        public int TeamId { get; set; }
    }
}
