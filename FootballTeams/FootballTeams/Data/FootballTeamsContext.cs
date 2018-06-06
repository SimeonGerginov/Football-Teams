using FootballTeams.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Data
{
    public class FootballTeamsContext : DbContext
    {
        public FootballTeamsContext()
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballTeams;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Cities__country___286302EC");
            });

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

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FootballManagers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FootballM__team___34C8D9D1");
            });

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

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FootballPlayers)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FootballP__team___37A5467C");
            });

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

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Teams__city_id__30F848ED");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Teams__country_i__300424B4");

                entity.HasOne(d => d.FootballPresident)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.FootballPresidentId)
                    .HasConstraintName("FK__Teams__footballP__31EC6D26");

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("FK__Teams__stadium_i__2F10007B");
            });
        }
    }
}
