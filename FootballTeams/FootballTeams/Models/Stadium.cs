using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FootballTeams.Infrastructure;

namespace FootballTeams.Models
{
    public class Stadium
    {
        private ICollection<Team> teams;

        public Stadium()
        {
            this.teams = new HashSet<Team>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.StadiumNameMaxLength, MinimumLength = GlobalConstants.StadiumNameMinLength)]
        public string Name { get; set; }
        
        [Required]
        [Range(GlobalConstants.MinCapacity, GlobalConstants.MaxCapacity)]
        public int Capacity { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
