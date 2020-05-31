using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateState2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 6, 13, 11, 38, 285, DateTimeKind.Local).AddTicks(9340), new DateTime(2020, 1, 6, 13, 11, 38, 289, DateTimeKind.Local).AddTicks(6015) });

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

            migrationBuilder.InsertData(
                table: "CheckCenterStates",
                columns: new[] { "Id", "Description", "SourceId", "Title" },
                values: new object[] { 5, "Issue marked as duplicate", 4, "Duplicate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 6, 12, 58, 0, 485, DateTimeKind.Local).AddTicks(7043), new DateTime(2020, 1, 6, 12, 58, 0, 489, DateTimeKind.Local).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 6, 12, 58, 0, 490, DateTimeKind.Local).AddTicks(6302));
        }
    }
}
