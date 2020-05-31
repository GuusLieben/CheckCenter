using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveEventFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId",
                table: "CheckCenterComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId",
                table: "CheckCenterFeedback");

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 16, 2, 581, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 16, 2, 581, DateTimeKind.Local).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 16, 2, 581, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 16, 2, 581, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 7, 22, 16, 2, 576, DateTimeKind.Local).AddTicks(8834), new DateTime(2020, 1, 7, 22, 16, 2, 580, DateTimeKind.Local).AddTicks(9035) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 16, 2, 581, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 16, 2, 581, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId",
                table: "CheckCenterActionLogs",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId",
                table: "CheckCenterAdditionalInfo",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId",
                table: "CheckCenterComments",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId",
                table: "CheckCenterFeedback",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId",
                table: "CheckCenterComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId",
                table: "CheckCenterFeedback");

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 0, 50, 269, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 0, 50, 269, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 0, 50, 270, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 0, 50, 270, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 7, 22, 0, 50, 265, DateTimeKind.Local).AddTicks(1971), new DateTime(2020, 1, 7, 22, 0, 50, 269, DateTimeKind.Local).AddTicks(2891) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 0, 50, 270, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 7, 22, 0, 50, 270, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId",
                table: "CheckCenterActionLogs",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId",
                table: "CheckCenterAdditionalInfo",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId",
                table: "CheckCenterComments",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId",
                table: "CheckCenterFeedback",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id");
        }
    }
}
