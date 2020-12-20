namespace Pracka.Cup.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using Microsoft.Extensions.Configuration;
    using Pracka.Cup.Database.Data;
    using Pracka.Cup.Database.Models;

    public class CupContext : DbContext
    {
        public CupContext(DbContextOptions<CupContext> options)
            : base(options)
        { }

        public DbSet<ScoreBoardModel> ScoreBoards { get; set; }
        public DbSet<PlayerHistoryModel> PlayerHistories { get; set; }
        public DbSet<HistoryModel> Histories { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("PRACKA_CUP_CONNECTION_STRING");
                options.UseSqlServer(connectionString);
            }
        }

        private ValueConverter<DateTime, DateTime> GetDateTimeConverter()
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            return dateTimeConverter;
        }
        private ValueConverter<DateTime?, DateTime?> GetNullableDateTimeConverter()
        {
            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? v.Value.ToUniversalTime() : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
            return nullableDateTimeConverter;
        }
        private void SetAllDateTimePropertiesAsUTC(IEnumerable<IMutableProperty> properties)
        {
            foreach (var property in properties)
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(GetDateTimeConverter());
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(GetNullableDateTimeConverter());
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dateTimeConverter = new DateTimeToBinaryConverter();
            #region Team
            modelBuilder.Entity<TeamModel>()
                .HasKey((team) => team.Id);

            modelBuilder.Entity<TeamModel>()
                .Property((team) => team.CreatedUTC)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getutcdate()")
                .HasConversion(dateTimeConverter);

            modelBuilder.Entity<TeamModel>()
                .Property((team) => team.ModifiedUTC)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getutcdate()")
                .HasConversion(dateTimeConverter);

            SetAllDateTimePropertiesAsUTC(modelBuilder.Entity<TeamModel>().Metadata.GetProperties());
            modelBuilder.Entity<TeamModel>().HasData(InitialTeams.Get());
            #endregion Team

            #region Player
            modelBuilder.Entity<PlayerModel>()
               .HasKey((player) => player.Id);

            modelBuilder.Entity<PlayerModel>()
               .Property((player) => player.CreatedUTC)
               .HasDefaultValueSql("getutcdate()")
               .ValueGeneratedOnAdd()
               .HasConversion(dateTimeConverter);

            modelBuilder.Entity<PlayerModel>()
               .Property((player) => player.ModifiedUTC)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("getutcdate()")
               .HasConversion(dateTimeConverter);

            modelBuilder.Entity<PlayerModel>()
               .HasOne((player) => player.SelectedTeam)
               .WithMany((team) => team.PastPlayers)
               .HasForeignKey((player) => player.SelectedTeamId);

            SetAllDateTimePropertiesAsUTC(modelBuilder.Entity<PlayerModel>().Metadata.GetProperties());
            modelBuilder.Entity<PlayerModel>()
                .HasData(InitialPlayers.Get());
            #endregion Player

            #region History
            modelBuilder.Entity<HistoryModel>()
               .HasKey((history) => history.Id);

            modelBuilder.Entity<HistoryModel>()
               .Property((history) => history.CreatedUTC)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("getutcdate()")
               .HasConversion(dateTimeConverter);

            modelBuilder.Entity<HistoryModel>()
               .Property((history) => history.ModifiedUTC)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("getutcdate()")
               .HasConversion(dateTimeConverter);

            modelBuilder.Entity<HistoryModel>()
               .Property((history) => history.GameDateUTC)
               .HasConversion(dateTimeConverter)
               .IsRequired();

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

            SetAllDateTimePropertiesAsUTC(modelBuilder.Entity<HistoryModel>().Metadata.GetProperties());
            #endregion History

            #region PlayerHistory
            modelBuilder.Entity<PlayerHistoryModel>()
                .HasNoKey()
                .Ignore("Id")
                .ToView("PlayerHistoriesView");

            modelBuilder.Entity<ScoreBoardModel>()
                .HasNoKey()
                .ToView("ScoreBoardView");
            #endregion PlayerHistory
        }
    }

    public class CupContextFactory : IDesignTimeDbContextFactory<CupContext>
    {
        private readonly IConfiguration _configuration;
        public CupContextFactory()
        {
            _configuration = null;
        }
        public CupContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public CupContext CreateDbContext(string[] args)
        {
            var connectionString = null != args && args.Length > 0
                ? args[0]
                : _configuration?.GetConnectionString("PRACKA_CUP_CONNECTION_STRING")
                    ?? Environment.GetEnvironmentVariable("PRACKA_CUP_CONNECTION_STRING");

            var optionsBuilder = new DbContextOptionsBuilder<CupContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CupContext(optionsBuilder.Options);
        }
    }
}