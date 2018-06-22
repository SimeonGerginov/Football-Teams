using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;

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
        [StringLength(GlobalConstants.TeamNameMaxLength, MinimumLength = GlobalConstants.TeamNameMinLength)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.TeamAliasMaxLength, MinimumLength = GlobalConstants.TeamAliasMinLength)]
        public string Alias { get; set; }
        
        [Required]
        [Range(GlobalConstants.TeamEstablishedMinYear, GlobalConstants.TeamEstablishedMaxYear)]
        public int Established { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.TeamRegionMaxLength, MinimumLength = GlobalConstants.TeamRegionMinLength)]
        public string Region { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.TeamDivisionMaxLength, MinimumLength = GlobalConstants.TeamDivisionMinLength)]
        public string Division { get; set; }
        
        public int? Trophies { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.TeamCaptainNameMaxLength,
            MinimumLength = GlobalConstants.TeamCaptainNameMinLength)]
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
