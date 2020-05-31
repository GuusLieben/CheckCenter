using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "CheckCenterEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Content", "Created" },
                values: new object[] { "Recurring issue, cause known but no fix available yet", new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(5229) });

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Content", "Created" },
                values: new object[] { "Snoozed issue for 36 hours", new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Added", "Description", "Finished", "Removed", "Shorthand", "Title", "Updated" },
                values: new object[] { new DateTime(2019, 12, 31, 11, 21, 28, 567, DateTimeKind.Local).AddTicks(1142), "Ods - Breda/Warn: 1 MTs missing from Oltp", new DateTime(2019, 12, 31, 11, 21, 28, 570, DateTimeKind.Local).AddTicks(8386), new DateTime(2019, 12, 31, 11, 21, 28, 570, DateTimeKind.Local).AddTicks(9375), "s0sd009ds", "Ods -1MTs from Oltp", new DateTime(2019, 12, 31, 11, 21, 28, 570, DateTimeKind.Local).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Content", "Created" },
                values: new object[] { "@gli23 you didn't mark the issue as recurring", new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Content", "Created" },
                values: new object[] { "@gli23 you didn't update the state to UI", new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(5184) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "CheckCenterEvents");

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 19, 12, 23, 20, 506, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 19, 12, 23, 20, 507, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Content", "Created" },
                values: new object[] { "Ignore this check", new DateTime(2019, 12, 19, 12, 23, 20, 507, DateTimeKind.Local).AddTicks(2422) });

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Content", "Created" },
                values: new object[] { "Nevermind", new DateTime(2019, 12, 19, 12, 23, 20, 507, DateTimeKind.Local).AddTicks(2430) });

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Added", "Description", "Finished", "Removed", "Shorthand", "Title" },
                values: new object[] { new DateTime(2019, 12, 19, 12, 23, 20, 503, DateTimeKind.Local).AddTicks(3311), "Amsterdam has no supporters", new DateTime(2019, 12, 19, 12, 23, 20, 506, DateTimeKind.Local).AddTicks(5633), new DateTime(2019, 12, 19, 12, 23, 20, 506, DateTimeKind.Local).AddTicks(6640), "Event1 unique identifier", "AXAmsterdamn No Tickets" });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Content", "Created" },
                values: new object[] { "You forgot something", new DateTime(2019, 12, 19, 12, 23, 20, 507, DateTimeKind.Local).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Content", "Created" },
                values: new object[] { "You didn't do it right", new DateTime(2019, 12, 19, 12, 23, 20, 507, DateTimeKind.Local).AddTicks(2387) });
        }
    }
}
