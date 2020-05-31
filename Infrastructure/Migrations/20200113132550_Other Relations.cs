using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class OtherRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "CheckCenterFeedback",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "CheckCenterAdditionalInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId1",
                table: "CheckCenterActionLogs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 25, 49, 579, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "CheckCenterActionLogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 25, 49, 579, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 25, 49, 580, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "CheckCenterComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 25, 49, 580, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "CheckCenterEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Added", "Updated" },
                values: new object[] { new DateTime(2020, 1, 13, 14, 25, 49, 576, DateTimeKind.Local).AddTicks(7463), new DateTime(2020, 1, 13, 14, 25, 49, 579, DateTimeKind.Local).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 25, 49, 579, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "CheckCenterFeedback",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2020, 1, 13, 14, 25, 49, 580, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterFeedback_EventId1",
                table: "CheckCenterFeedback",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterAdditionalInfo_EventId1",
                table: "CheckCenterAdditionalInfo",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterActionLogs_EventId1",
                table: "CheckCenterActionLogs",
                column: "EventId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId1",
                table: "CheckCenterActionLogs",
                column: "EventId1",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId1",
                table: "CheckCenterAdditionalInfo",
                column: "EventId1",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId1",
                table: "CheckCenterFeedback",
                column: "EventId1",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId1",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId1",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId1",
                table: "CheckCenterFeedback");

            migrationBuilder.DropIndex(
                name: "IX_CheckCenterFeedback_EventId1",
                table: "CheckCenterFeedback");

            migrationBuilder.DropIndex(
                name: "IX_CheckCenterAdditionalInfo_EventId1",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropIndex(
                name: "IX_CheckCenterActionLogs_EventId1",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "CheckCenterFeedback");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "CheckCenterActionLogs");

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
        }
    }
}
