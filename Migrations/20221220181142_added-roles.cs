using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trevoir.Migrations
{
    /// <inheritdoc />
    public partial class addedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cabce8c-0e3a-4032-b858-47837cfe24c6", "cd8e77e0-1f00-4582-81c7-a19984950124", "User", "USER" },
                    { "7bf1a4fa-3719-44fd-8ede-bcc2909c8e40", "c266b9d3-e887-4abf-9d56-6915aeab8026", "Admin", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cabce8c-0e3a-4032-b858-47837cfe24c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bf1a4fa-3719-44fd-8ede-bcc2909c8e40");
        }
    }
}
