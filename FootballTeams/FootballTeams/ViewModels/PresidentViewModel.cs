using System.ComponentModel.DataAnnotations;

namespace FootballTeams.ViewModels
{
    public class PresidentViewModel
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
