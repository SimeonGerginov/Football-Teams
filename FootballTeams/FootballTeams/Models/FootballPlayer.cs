namespace FootballTeams.Models
{
    public class FootballPlayer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        public string Nationality { get; set; }

        public int? TrophiesWon { get; set; }

        public int? TeamId { get; set; }

        public Team Team { get; set; }
    }
}
