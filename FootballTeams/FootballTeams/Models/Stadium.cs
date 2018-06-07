using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        public int Capacity { get; set; }

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
