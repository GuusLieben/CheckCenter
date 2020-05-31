using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class LoggingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "CheckCenterAdditionalInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "CheckCenterActionLogs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 8, 11, 38, 30, 932, DateTimeKind.Local).AddTicks(6595), new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(765) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 38, 30, 937, DateTimeKind.Local).AddTicks(7217));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "CheckCenterAdditionalInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "CheckCenterActionLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 8, 11, 35, 36, 658, DateTimeKind.Local).AddTicks(1349), new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 35, 36, 662, DateTimeKind.Local).AddTicks(9634));
        }
    }
}
