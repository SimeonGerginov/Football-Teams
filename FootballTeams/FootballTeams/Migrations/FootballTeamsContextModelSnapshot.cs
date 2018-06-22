﻿// <auto-generated />
using FootballTeams.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FootballTeams.Migrations
{
    [DbContext(typeof(FootballTeamsContext))]
    partial class FootballTeamsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballTeams.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FootballTeams.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FootballTeams.Models.FootballManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TrophiesWon");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("FootballManagers");
                });

            modelBuilder.Entity("FootballTeams.Models.FootballPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int?>("TeamId");

                    b.Property<int?>("TrophiesWon");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("FootballPlayers");
                });

            modelBuilder.Entity("FootballTeams.Models.FootballPresident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("FootballPresidents");
                });

            modelBuilder.Entity("FootballTeams.Models.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("FootballTeams.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Captain")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int?>("CityId");

                    b.Property<int?>("CountryId");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Established");

                    b.Property<int?>("FootballPresidentId");

                    b.Property<int?>("LostMatches");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int?>("PlayedMatches");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("StadiumId");

                    b.Property<int?>("Trophies");

                    b.Property<int?>("WonMatches");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("FootballPresidentId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FootballTeams.Models.City", b =>
                {
                    b.HasOne("FootballTeams.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("FootballTeams.Models.FootballManager", b =>
                {
                    b.HasOne("FootballTeams.Models.Team", "Team")
                        .WithMany("FootballManagers")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("FootballTeams.Models.FootballPlayer", b =>
                {
                    b.HasOne("FootballTeams.Models.Team", "Team")
                        .WithMany("FootballPlayers")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("FootballTeams.Models.Team", b =>
                {
                    b.HasOne("FootballTeams.Models.City", "City")
                        .WithMany("Teams")
                        .HasForeignKey("CityId");

                    b.HasOne("FootballTeams.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryId");

                    b.HasOne("FootballTeams.Models.FootballPresident", "FootballPresident")
                        .WithMany("Teams")
                        .HasForeignKey("FootballPresidentId");

                    b.HasOne("FootballTeams.Models.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("StadiumId");
                });
#pragma warning restore 612, 618
        }
    }
}
