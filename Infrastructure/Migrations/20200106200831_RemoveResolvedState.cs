using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveResolvedState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckCenterStates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 6, 21, 8, 30, 748, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 6, 21, 8, 30, 748, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 6, 21, 8, 30, 748, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 6, 21, 8, 30, 748, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "StateId", "Updated" },
                values: new object[] { new DateTime(2020, 1, 6, 21, 8, 30, 744, DateTimeKind.Local).AddTicks(1086), 3, new DateTime(2020, 1, 6, 21, 8, 30, 747, DateTimeKind.Local).AddTicks(8725) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 6, 21, 8, 30, 748, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 6, 21, 8, 30, 748, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "CheckCenterStates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Issue marked as duplicate", "Duplicate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 6, 13, 11, 38, 290, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 6, 13, 11, 38, 290, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 6, 13, 11, 38, 290, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 6, 13, 11, 38, 290, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "StateId", "Updated" },
                values: new object[] { new DateTime(2020, 1, 6, 13, 11, 38, 285, DateTimeKind.Local).AddTicks(9340), 2, new DateTime(2020, 1, 6, 13, 11, 38, 289, DateTimeKind.Local).AddTicks(6015) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 6, 13, 11, 38, 290, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 6, 13, 11, 38, 290, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "CheckCenterStates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Issue has been resolved", "Resolved" });

            migrationBuilder.InsertData(
                table: "CheckCenterStates",
                columns: new[] { "Id", "Description", "SourceId", "Title" },
                values: new object[] { 5, "Issue marked as duplicate", 4, "Duplicate" });
        }
    }
}
