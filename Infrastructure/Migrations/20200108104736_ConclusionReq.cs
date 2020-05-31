using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ConclusionReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 47, 35, 442, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 47, 35, 442, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 47, 35, 443, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 47, 35, 443, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 8, 11, 47, 35, 438, DateTimeKind.Local).AddTicks(4905), new DateTime(2020, 1, 8, 11, 47, 35, 442, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 47, 35, 442, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 8, 11, 47, 35, 443, DateTimeKind.Local).AddTicks(493));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
