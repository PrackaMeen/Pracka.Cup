namespace Pracka.Cup.Database.Helpers
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using System;

    public static class DataFirstHelpers
    {
        public static void AddCustomFunction<T>(this MigrationBuilder migrationBuilder)
            where T : IDatabaseFunction, new()
        {
            var functionToCreateOrAlter = Activator.CreateInstance<T>();
            migrationBuilder.Sql(functionToCreateOrAlter.CreateOrAlterQuery);
        }

        public static void DropCustomFunction<T>(this MigrationBuilder migrationBuilder)
            where T : IDatabaseFunction, new()
        {
            var functionToDrop = Activator.CreateInstance<T>();
            migrationBuilder.Sql(functionToDrop.DropQuery);
        }
    }
}
