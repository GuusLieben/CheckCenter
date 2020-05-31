using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.IdentityDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserEmail = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserEmail);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserEmail", "FirstName", "LastName", "Password" },
                values: new object[] { "admin@cm.com", "Admin", "", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
