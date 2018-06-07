using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballTeams.Models
{
    public class Team
    {
        private ICollection<FootballManager> managers;
        private ICollection<FootballPlayer> players;

        public Team()
        {
            FootballManagers = new HashSet<FootballManager>();
            FootballPlayers = new HashSet<FootballPlayer>();
        }
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Alias { get; set; }
        
        [Required]
        public int Established { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Region { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string Division { get; set; }
        
        public int? Trophies { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Captain { get; set; }
        
        public int? PlayedMatches { get; set; }
        
        public int? WonMatches { get; set; }
        
        public int? LostMatches { get; set; }

        public int? StadiumId { get; set; }
        
        public Stadium Stadium { get; set; }

        public int? CityId { get; set; }
        
        public City City { get; set; }

        public int? CountryId { get; set; }
        
        public Country Country { get; set; }

        public int? FootballPresidentId { get; set; }
        
        public FootballPresident FootballPresident { get; set; }

        public ICollection<FootballManager> FootballManagers
        {
            get { return this.managers; }
            set { this.managers = value; }
        }

        public ICollection<FootballPlayer> FootballPlayers
        {
            get { return this.players; }
            set { this.players = value; }
        }
    }
}
