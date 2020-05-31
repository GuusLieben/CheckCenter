using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.IdentityDb
{
    public partial class MockDataUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserEmail",
                keyValue: "admin@cm.com",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "NOC", "Monitoring" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserEmail",
                keyValue: "admin@cm.com",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Admin", "" });
        }
    }
}
