using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.ArchiveDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckCenterActionLogs",
                columns: table => new
                {
                    StoredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    OldStateId = table.Column<int>(nullable: false),
                    NewStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterActionLogs", x => x.StoredId);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterAdditionalInfo",
                columns: table => new
                {
                    StoredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterAdditionalInfo", x => x.StoredId);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterComments",
                columns: table => new
                {
                    StoredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterComments", x => x.StoredId);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterFeedback",
                columns: table => new
                {
                    StoredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterFeedback", x => x.StoredId);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterFinishedEvents",
                columns: table => new
                {
                    StoredId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Added = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Conclusion = table.Column<string>(nullable: true),
                    EventSeverity = table.Column<int>(nullable: false),
                    Shorthand = table.Column<string>(nullable: false),
                    SourceId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CheckTypeId = table.Column<int>(nullable: false),
                    Removed = table.Column<DateTime>(nullable: false),
                    Finished = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterFinishedEvents", x => x.StoredId);
                });

            migrationBuilder.InsertData(
                table: "CheckCenterActionLogs",
                columns: new[] { "StoredId", "Created", "EventId", "Id", "NewStateId", "OldStateId", "UserEmail" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(3129), 1, 1, 2, -1, "tvw203@gmail.com" },
                    { 2, new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(5192), 1, 2, 3, 2, "tvw203@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterAdditionalInfo",
                columns: new[] { "StoredId", "EventId", "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "Amount of tickets", "0" },
                    { 2, 1, 2, "Location", "Amsterdam" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterComments",
                columns: new[] { "StoredId", "Content", "Created", "EventId", "Id", "UserEmail" },
                values: new object[,]
                {
                    { 1, "Recurring issue, cause known but no fix available yet", new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(6429), 1, 1, "tvw203@gmail.com" },
                    { 2, "Snoozed issue for 36 hours", new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(6438), 1, 2, "tvw203@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterFeedback",
                columns: new[] { "StoredId", "Content", "Created", "EventId", "Id", "UserEmail" },
                values: new object[,]
                {
                    { 1, "@gli23 you didn't mark the issue as recurring", new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(5246), 1, 1, "tvw203@gmail.com" },
                    { 2, "@gli23 you didn't update the state to UI", new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(6395), 1, 2, "iemand@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterFinishedEvents",
                columns: new[] { "StoredId", "Added", "CheckTypeId", "Conclusion", "Description", "EventSeverity", "Finished", "Id", "Removed", "Shorthand", "SourceId", "StateId", "Title", "Updated" },
                values: new object[] { 1, new DateTime(2020, 1, 8, 12, 3, 3, 280, DateTimeKind.Local).AddTicks(5264), 1, null, "Ods - Breda/Warn: 1 MTs missing from Oltp", 300, new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(715), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "s0sd009ds", 4, 2, "Ods -1MTs from Oltp", new DateTime(2020, 1, 8, 12, 3, 3, 284, DateTimeKind.Local).AddTicks(685) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckCenterActionLogs");

            migrationBuilder.DropTable(
                name: "CheckCenterAdditionalInfo");

            migrationBuilder.DropTable(
                name: "CheckCenterComments");

            migrationBuilder.DropTable(
                name: "CheckCenterFeedback");

            migrationBuilder.DropTable(
                name: "CheckCenterFinishedEvents");
        }
    }
}
