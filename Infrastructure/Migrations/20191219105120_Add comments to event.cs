using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Addcommentstoevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventID1",
                table: "CheckCenterComments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Added", "Finished", "Removed" },
                values: new object[] { new DateTime(2019, 12, 19, 11, 51, 19, 526, DateTimeKind.Local).AddTicks(4129), new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(422), new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 19, 11, 51, 19, 530, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterComments_EventID1",
                table: "CheckCenterComments",
                column: "EventID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventID1",
                table: "CheckCenterComments",
                column: "EventID1",
                principalTable: "CheckCenterEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventID1",
                table: "CheckCenterComments");

            migrationBuilder.DropIndex(
                name: "IX_CheckCenterComments_EventID1",
                table: "CheckCenterComments");

            migrationBuilder.DropColumn(
                name: "EventID1",
                table: "CheckCenterComments");

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "ID",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 19, 10, 57, 9, 406, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "ID",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 19, 10, 57, 9, 406, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Added", "Finished", "Removed" },
                values: new object[] { new DateTime(2019, 12, 19, 10, 57, 9, 402, DateTimeKind.Local).AddTicks(3010), new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(3904), new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 19, 10, 57, 9, 406, DateTimeKind.Local).AddTicks(412));
        }
    }
}
