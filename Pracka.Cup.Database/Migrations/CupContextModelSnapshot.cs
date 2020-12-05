﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pracka.Cup.Database;

namespace Pracka.Cup.Database.Migrations
{
    [DbContext(typeof(CupContext))]
    partial class CupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pracka.Cup.Database.Models.HistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedUTC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7601));

                    b.Property<DateTime>("GameDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalsAwayTeam")
                        .HasColumnType("int");

                    b.Property<int>("GoalsHomeTeam")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedUTC")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7865));

                    b.Property<int>("PlayerAwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerHomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("ResultKindAwayTeam")
                        .HasColumnType("int");

                    b.Property<int>("ResultKindHomeTeam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("PlayerAwayTeamId");

                    b.HasIndex("PlayerHomeTeamId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Pracka.Cup.Database.Models.PlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUTC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(953));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedUTC")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(1263));

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SelectedTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SelectedTeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4193),
                            FirstName = "Player",
                            LastName = "1",
                            ModifiedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4198),
                            Nickname = "Player1",
                            SelectedTeamId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4520),
                            FirstName = "Player",
                            LastName = "2",
                            ModifiedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4522),
                            Nickname = "Player2",
                            SelectedTeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4529),
                            FirstName = "Player",
                            LastName = "3",
                            ModifiedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4530),
                            Nickname = "Player3",
                            SelectedTeamId = 3
                        });
                });

            modelBuilder.Entity("Pracka.Cup.Database.Models.TeamModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUTC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 5, 20, 40, 46, 547, DateTimeKind.Utc).AddTicks(9746));

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedUTC")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 12, 5, 20, 40, 46, 551, DateTimeKind.Utc).AddTicks(7729));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 561, DateTimeKind.Utc).AddTicks(6724),
                            Icon = "BOSTON_BRUINS",
                            ModifiedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(2290),
                            Name = "Boston"
                        },
                        new
                        {
                            Id = 2,
                            CreatedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(3377),
                            Icon = "BUFFALO_SABRES",
                            ModifiedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(3393),
                            Name = "Buffalo"
                        },
                        new
                        {
                            Id = 3,
                            CreatedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(3418),
                            Icon = "PHILADELPHIA_FLYERS",
                            ModifiedUTC = new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(3420),
                            Name = "Philadelpia"
                        });
                });

            modelBuilder.Entity("Pracka.Cup.Database.Models.HistoryModel", b =>
                {
                    b.HasOne("Pracka.Cup.Database.Models.TeamModel", "AwayTeam")
                        .WithMany("AwayTeamHistories")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pracka.Cup.Database.Models.TeamModel", "HomeTeam")
                        .WithMany("HomeTeamHistories")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pracka.Cup.Database.Models.PlayerModel", "PlayerAwayTeam")
                        .WithMany("AwayGameHistories")
                        .HasForeignKey("PlayerAwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pracka.Cup.Database.Models.PlayerModel", "PlayerHomeTeam")
                        .WithMany("HomeGameHistories")
                        .HasForeignKey("PlayerHomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Pracka.Cup.Database.Models.PlayerModel", b =>
                {
                    b.HasOne("Pracka.Cup.Database.Models.TeamModel", "SelectedTeam")
                        .WithMany("PastPlayers")
                        .HasForeignKey("SelectedTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
