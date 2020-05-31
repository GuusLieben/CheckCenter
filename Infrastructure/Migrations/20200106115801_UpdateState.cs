using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 3, 17, 1, 13, 689, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 3, 17, 1, 13, 689, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 3, 17, 1, 13, 689, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 3, 17, 1, 13, 689, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 3, 17, 1, 13, 685, DateTimeKind.Local).AddTicks(5843), new DateTime(2020, 1, 3, 17, 1, 13, 688, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 3, 17, 1, 13, 689, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 3, 17, 1, 13, 689, DateTimeKind.Local).AddTicks(6539));
        }
    }
}
