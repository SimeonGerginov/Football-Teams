namespace FootballTeams.Models
{
    public class FootballManager
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int? TrophiesWon { get; set; }

        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
