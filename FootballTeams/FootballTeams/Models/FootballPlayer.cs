using System.ComponentModel.DataAnnotations;

namespace FootballTeams.Models
{
    public class FootballPlayer
    {
        [Key]
        public int Id { get; set; }
        
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
        
        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
