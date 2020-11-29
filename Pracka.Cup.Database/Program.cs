using Microsoft.EntityFrameworkCore;
using System;

namespace Pracka.Cup.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CupContextFactory().CreateDbContext(null))
            {
                context.Database.MigrateAsync();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
