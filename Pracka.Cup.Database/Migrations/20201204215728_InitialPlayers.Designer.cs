﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pracka.Cup.Database;

namespace Pracka.Cup.Database.Migrations
{
    [DbContext(typeof(CupContext))]
    [Migration("20201204215728_InitialPlayers")]
    partial class InitialPlayers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalsAwayTeam")
                        .HasColumnType("int");

                    b.Property<int>("GoalsHomeTeam")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

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

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

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
                            Created = new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(635),
                            FirstName = "Player",
                            LastName = "1",
                            Modified = new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(640),
                            Nickname = "Player1",
                            SelectedTeamId = 2
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(966),
                            FirstName = "Player",
                            LastName = "2",
                            Modified = new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(969),
                            Nickname = "Player2",
                            SelectedTeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(976),
                            FirstName = "Player",
                            LastName = "3",
                            Modified = new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(977),
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

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2020, 12, 4, 22, 57, 28, 5, DateTimeKind.Local).AddTicks(1611),
                            Icon = "BOSTON_BRUINS",
                            Modified = new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(8353),
                            Name = "Boston"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9447),
                            Icon = "BUFFALO_SABRES",
                            Modified = new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9464),
                            Name = "Buffalo"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9482),
                            Icon = "PHILADELPHIA_FLYERS",
                            Modified = new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9485),
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