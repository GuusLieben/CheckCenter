using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Move_Finish_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "CheckCenterEvents");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "CheckCenterEvents");

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 31, 18, 2, 35, 541, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 31, 18, 2, 35, 541, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 31, 18, 2, 35, 542, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 31, 18, 2, 35, 542, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2019, 12, 31, 18, 2, 35, 537, DateTimeKind.Local).AddTicks(1945), new DateTime(2019, 12, 31, 18, 2, 35, 541, DateTimeKind.Local).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 31, 18, 2, 35, 542, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 31, 18, 2, 35, 542, DateTimeKind.Local).AddTicks(1486));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Finished",
                table: "CheckCenterEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Removed",
                table: "CheckCenterEvents",
                type: "datetime2",
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
                column: "Created",
                value: new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Added", "Finished", "Removed", "Updated" },
                values: new object[] { new DateTime(2019, 12, 31, 11, 21, 28, 567, DateTimeKind.Local).AddTicks(1142), new DateTime(2019, 12, 31, 11, 21, 28, 570, DateTimeKind.Local).AddTicks(8386), new DateTime(2019, 12, 31, 11, 21, 28, 570, DateTimeKind.Local).AddTicks(9375), new DateTime(2019, 12, 31, 11, 21, 28, 570, DateTimeKind.Local).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 31, 11, 21, 28, 571, DateTimeKind.Local).AddTicks(5184));
        }
    }
}
