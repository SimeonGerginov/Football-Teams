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
            this.CountriesConfiguration(modelBuilder);
            this.FootballManagersConfiguration(modelBuilder);
            this.FootballPlayersConfiguration(modelBuilder);
            this.FootballPresidentsConfiguration(modelBuilder);
            this.StadiumsConfiguration(modelBuilder);   
            this.TeamsConfiguration(modelBuilder);
        }

        private void CitiesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(e => e.Country)
                    .WithMany(c => c.Cities)
                    .HasForeignKey(e => e.CountryId)
                    .HasConstraintName("FK__Cities__country___286302EC");
            });
        }

        private void CountriesConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }

        private void FootballManagersConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballManager>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TrophiesWon).HasColumnName("trophies_won");

                entity.HasOne(m => m.Team)
                    .WithMany(t => t.FootballManagers)
                    .HasForeignKey(m => m.TeamId)
                    .HasConstraintName("FK__FootballM__team___34C8D9D1");
            });
        }

        private void FootballPlayersConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballPlayer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnName("nationality")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TrophiesWon).HasColumnName("trophies_won");

                entity.HasOne(p => p.Team)
                    .WithMany(t => t.FootballPlayers)
                    .HasForeignKey(p => p.TeamId)
                    .HasConstraintName("FK__FootballP__team___37A5467C");
            });
        }

        private void FootballPresidentsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballPresident>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }

        private void StadiumsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }

        private void TeamsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Captain)
                    .IsRequired()
                    .HasColumnName("captain")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Division)
                    .IsRequired()
                    .HasColumnName("division")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Established).HasColumnName("established");

                entity.Property(e => e.FootballPresidentId).HasColumnName("footballPresident_id");

                entity.Property(e => e.LostMatches).HasColumnName("lost_matches");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlayedMatches).HasColumnName("played_matches");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StadiumId).HasColumnName("stadium_id");

                entity.Property(e => e.Trophies).HasColumnName("trophies");

                entity.Property(e => e.WonMatches).HasColumnName("won_matches");

                entity.HasOne(t => t.City)
                    .WithMany(c => c.Teams)
                    .HasForeignKey(t => t.CityId)
                    .HasConstraintName("FK__Teams__city_id__30F848ED");

                entity.HasOne(t => t.Country)
                    .WithMany(c => c.Teams)
                    .HasForeignKey(t => t.CountryId)
                    .HasConstraintName("FK__Teams__country_i__300424B4");

                entity.HasOne(t => t.FootballPresident)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(t => t.FootballPresidentId)
                    .HasConstraintName("FK__Teams__footballP__31EC6D26");

                entity.HasOne(t => t.Stadium)
                    .WithMany(s => s.Teams)
                    .HasForeignKey(t => t.StadiumId)
                    .HasConstraintName("FK__Teams__stadium_i__2F10007B");
            });
        }
    }
}
