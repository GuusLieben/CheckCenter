using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CommentRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "CheckCenterComments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 17, 48, 908, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 17, 48, 908, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 17, 48, 908, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 17, 48, 908, DateTimeKind.Local).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 13, 14, 17, 48, 905, DateTimeKind.Local).AddTicks(4375), new DateTime(2020, 1, 13, 14, 17, 48, 907, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 17, 48, 908, DateTimeKind.Local).AddTicks(3286));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 17, 48, 908, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterComments_EventId1",
                table: "CheckCenterComments",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId1",
                table: "CheckCenterComments",
                column: "EventId1",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId1",
                table: "CheckCenterComments");

            migrationBuilder.DropIndex(
                name: "IX_CheckCenterComments_EventId1",
                table: "CheckCenterComments");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "CheckCenterComments");

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
    }
}
