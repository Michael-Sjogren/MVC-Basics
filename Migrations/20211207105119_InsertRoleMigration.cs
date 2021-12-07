using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasics.Migrations
{
    public partial class InsertRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ee2a248-f872-4021-9a99-360a9b7d3915");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b140682-153f-441f-b4d9-3fa9609ae347");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76e403be-901a-4280-a8ee-b26c0efbd356", "f7ecf609-822f-4648-9ff4-f050c81f8a93", "User", "USER" },
                    { "76506ef3-12e5-430d-9c16-b3d760969f01", "0ca43035-7870-4208-8bb4-6b8a848a2a76", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                column: "CityId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                column: "CityId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7,
                column: "CityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8,
                column: "CityId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9,
                column: "CityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11,
                column: "CityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12,
                column: "CityId",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76506ef3-12e5-430d-9c16-b3d760969f01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76e403be-901a-4280-a8ee-b26c0efbd356");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ee2a248-f872-4021-9a99-360a9b7d3915", "95d486ab-784c-4114-a508-be2ea0022a97", "User", null },
                    { "7b140682-153f-441f-b4d9-3fa9609ae347", "e8beec25-c470-42a4-a85c-5a02398ea374", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "CityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "CityId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                column: "CityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                column: "CityId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8,
                column: "CityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9,
                column: "CityId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10,
                column: "CityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11,
                column: "CityId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12,
                column: "CityId",
                value: 3);
        }
    }
}
