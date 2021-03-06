﻿// <auto-generated />
using FootballTeams.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FootballTeams.Migrations
{
    [DbContext(typeof(FootballTeamsContext))]
    [Migration("20180621052524_AddedCountryCityAndStadium")]
    partial class AddedCountryCityAndStadium
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FootballTeams.Models.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("FootballTeams.Models.City", b =>
                {
                    b.HasOne("FootballTeams.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
