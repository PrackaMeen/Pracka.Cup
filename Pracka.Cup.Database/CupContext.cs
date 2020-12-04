namespace Pracka.Cup.Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Pracka.Cup.Database.Data;
    using Pracka.Cup.Database.Models;

    public class CupContext : DbContext
    {
        public CupContext(DbContextOptions<CupContext> options)
            : base(options)
        { }

        public DbSet<HistoryModel> Histories { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=PrackaCup;server=.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //team
            modelBuilder.Entity<TeamModel>()
                .HasKey((team) => team.Id);

            //player
            modelBuilder.Entity<PlayerModel>()
               .HasKey((player) => player.Id);

            modelBuilder.Entity<PlayerModel>()
               .HasOne((player) => player.SelectedTeam)
               .WithMany((team) => team.PastPlayers)
               .HasForeignKey((player) => player.SelectedTeamId);

            //history
            modelBuilder.Entity<HistoryModel>()
                .HasKey((history) => history.Id);

            modelBuilder.Entity<HistoryModel>()
                .HasOne((history) => history.HomeTeam)
                .WithMany((team) => team.HomeTeamHistories)
                .HasForeignKey((history) => history.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HistoryModel>()
                .HasOne((history) => history.AwayTeam)
                .WithMany((team) => team.AwayTeamHistories)
                .HasForeignKey((history) => history.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HistoryModel>()
                .HasOne((history) => history.PlayerHomeTeam)
                .WithMany((player) => player.HomeGameHistories)
                .HasForeignKey((history) => history.PlayerHomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistoryModel>()
                .HasOne((history) => history.PlayerAwayTeam)
                .WithMany((player) => player.AwayGameHistories)
                .HasForeignKey((history) => history.PlayerAwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamModel>().HasData(InitialTeams.Get());
            modelBuilder.Entity<PlayerModel>().HasData(InitialPlayers.Get());
        }
    }

    public class CupContextFactory : IDesignTimeDbContextFactory<CupContext>
    {
        public CupContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CupContext>();
            optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=PrackaCup;server=.");

            return new CupContext(optionsBuilder.Options);
        }
    }
}