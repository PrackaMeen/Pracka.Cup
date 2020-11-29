namespace Pracka.Cup.Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Pracka.Cup.Database.Models;

    public class CupContext : DbContext
    {
        public CupContext(DbContextOptions<CupContext> options)
            : base(options)
        { }

        public DbSet<HistoryModel> Histories { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<PlayerModel> Players { get; set; }
    }

    public class CupContextFactory : IDesignTimeDbContextFactory<CupContext>
    {
        public CupContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CupContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("PRACKA_CUP_CONNECTION_STRING"));

            return new CupContext(optionsBuilder.Options);
        }
    }
}