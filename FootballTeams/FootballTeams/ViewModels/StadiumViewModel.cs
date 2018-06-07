using System.ComponentModel.DataAnnotations;

namespace FootballTeams.ViewModels
{
    public class StadiumViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
