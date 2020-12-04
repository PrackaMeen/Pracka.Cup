using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class InitialPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Created", "FirstName", "LastName", "Modified", "Nickname", "SelectedTeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(635), "Player", "1", new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(640), "Player1", 2 },
                    { 2, new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(966), "Player", "2", new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(969), "Player2", 1 },
                    { 3, new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(976), "Player", "3", new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(977), "Player3", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 22, 57, 28, 5, DateTimeKind.Local).AddTicks(1611), new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9447), new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9482), new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9485) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 29, 21, 3, 55, 14, DateTimeKind.Local).AddTicks(6878), new DateTime(2020, 11, 29, 21, 3, 55, 18, DateTimeKind.Local).AddTicks(9413) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(468), new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(502), new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(505) });
        }
    }
}
