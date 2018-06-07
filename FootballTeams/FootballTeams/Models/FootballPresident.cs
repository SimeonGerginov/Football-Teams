using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballTeams.Models
{
    public class FootballPresident
    {
        private ICollection<Team> teams;

        public FootballPresident()
        {
            this.teams = new HashSet<Team>();
        }
        
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

        public ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
