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
    [Migration("20201129161236_InitialCreated")]
    partial class InitialCreated
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

                    b.Property<int?>("PlayerModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerModelId");

                    b.ToTable("Teams");
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

            modelBuilder.Entity("Pracka.Cup.Database.Models.TeamModel", b =>
                {
                    b.HasOne("Pracka.Cup.Database.Models.PlayerModel", null)
                        .WithMany("PastTeams")
                        .HasForeignKey("PlayerModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
