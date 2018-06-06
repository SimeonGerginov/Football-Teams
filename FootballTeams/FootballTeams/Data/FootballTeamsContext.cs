using FootballTeams.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Data
{
    public class FootballTeamsContext : DbContext
    {
        public FootballTeamsContext(DbContextOptions<FootballTeamsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<FootballManager> FootballManagers { get; set; }

        public virtual DbSet<FootballPlayer> FootballPlayers { get; set; }

        public virtual DbSet<FootballPresident> FootballPresidents { get; set; }

        public virtual DbSet<Stadium> Stadiums { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.CitiesConfiguration(modelBuilder);
            this.FootballManagersConfiguration(modelBuilder);
            this.FootballPlayersConfiguration(modelBuilder);
            this.TeamsConfiguration(modelBuilder);
        }

        private void CitiesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(e => e.Country)
                    .WithMany(c => c.Cities)
                    .HasForeignKey(e => e.CountryId);
            });
        }

        private void FootballManagersConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballManager>(entity =>
            {
                entity.HasOne(m => m.Team)
                    .WithMany(t => t.FootballManagers)
                    .HasForeignKey(m => m.TeamId);
            });
        }

        private void FootballPlayersConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballPlayer>(entity =>
            {
                entity.HasOne(p => p.Team)
                    .WithMany(t => t.FootballPlayers)
                    .HasForeignKey(p => p.TeamId);
            });
        }

        private void TeamsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(t => t.City)
                    .WithMany(c => c.Teams)
                    .HasForeignKey(t => t.CityId);

                entity.HasOne(t => t.Country)
                    .WithMany(c => c.Teams)
                    .HasForeignKey(t => t.CountryId);

                entity.HasOne(t => t.FootballPresident)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(t => t.FootballPresidentId);

                entity.HasOne(t => t.Stadium)
                    .WithMany(s => s.Teams)
                    .HasForeignKey(t => t.StadiumId);
            });
        }
    }
}
