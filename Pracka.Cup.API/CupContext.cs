namespace Pracka.Cup.API
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class CupContext : DbContext
    {
        public CupContext(DbContextOptions<CupContext> options)
            : base(options)
        { }

        public DbSet<Blog> Histories { get; set; }
        public DbSet<Post> Teams { get; set; }
        public DbSet<Post> Players { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
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