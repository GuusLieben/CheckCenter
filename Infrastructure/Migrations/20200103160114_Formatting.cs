using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Formatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventID",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_NewStateID",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_OldStateID",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventID",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventID",
                table: "CheckCenterComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterCheckTypes_CheckTypeID",
                table: "CheckCenterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterSources_SourceID",
                table: "CheckCenterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterStates_StateID",
                table: "CheckCenterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventID",
                table: "CheckCenterFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterSources_CheckCenterCheckTypes_CheckTypeID",
                table: "CheckCenterSources");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterStates_CheckCenterSources_SourceID",
                table: "CheckCenterStates");

            migrationBuilder.RenameColumn(
                name: "SourceID",
                table: "CheckCenterStates",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterStates",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterStates_SourceID",
                table: "CheckCenterStates",
                newName: "IX_CheckCenterStates_SourceId");

            migrationBuilder.RenameColumn(
                name: "CheckTypeID",
                table: "CheckCenterSources",
                newName: "CheckTypeId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterSources",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterSources_CheckTypeID",
                table: "CheckCenterSources",
                newName: "IX_CheckCenterSources_CheckTypeId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "CheckCenterFeedback",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterFeedback",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterFeedback_EventID",
                table: "CheckCenterFeedback",
                newName: "IX_CheckCenterFeedback_EventId");

            migrationBuilder.RenameColumn(
                name: "StateID",
                table: "CheckCenterEvents",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "SourceID",
                table: "CheckCenterEvents",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "CheckTypeID",
                table: "CheckCenterEvents",
                newName: "CheckTypeId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterEvents",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterEvents_StateID",
                table: "CheckCenterEvents",
                newName: "IX_CheckCenterEvents_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterEvents_SourceID",
                table: "CheckCenterEvents",
                newName: "IX_CheckCenterEvents_SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterEvents_CheckTypeID",
                table: "CheckCenterEvents",
                newName: "IX_CheckCenterEvents_CheckTypeId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "CheckCenterComments",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterComments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterComments_EventID",
                table: "CheckCenterComments",
                newName: "IX_CheckCenterComments_EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterCheckTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "CheckCenterAdditionalInfo",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterAdditionalInfo",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterAdditionalInfo_EventID",
                table: "CheckCenterAdditionalInfo",
                newName: "IX_CheckCenterAdditionalInfo_EventId");

            migrationBuilder.RenameColumn(
                name: "OldStateID",
                table: "CheckCenterActionLogs",
                newName: "OldStateId");

            migrationBuilder.RenameColumn(
                name: "NewStateID",
                table: "CheckCenterActionLogs",
                newName: "NewStateId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "CheckCenterActionLogs",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckCenterActionLogs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterActionLogs_OldStateID",
                table: "CheckCenterActionLogs",
                newName: "IX_CheckCenterActionLogs_OldStateId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterActionLogs_NewStateID",
                table: "CheckCenterActionLogs",
                newName: "IX_CheckCenterActionLogs_NewStateId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterActionLogs_EventID",
                table: "CheckCenterActionLogs",
                newName: "IX_CheckCenterActionLogs_EventId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId",
                table: "CheckCenterActionLogs",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_NewStateId",
                table: "CheckCenterActionLogs",
                column: "NewStateId",
                principalTable: "CheckCenterStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_OldStateId",
                table: "CheckCenterActionLogs",
                column: "OldStateId",
                principalTable: "CheckCenterStates",
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
                name: "FK_CheckCenterEvents_CheckCenterCheckTypes_CheckTypeId",
                table: "CheckCenterEvents",
                column: "CheckTypeId",
                principalTable: "CheckCenterCheckTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterSources_SourceId",
                table: "CheckCenterEvents",
                column: "SourceId",
                principalTable: "CheckCenterSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterStates_StateId",
                table: "CheckCenterEvents",
                column: "StateId",
                principalTable: "CheckCenterStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId",
                table: "CheckCenterFeedback",
                column: "EventId",
                principalTable: "CheckCenterEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterSources_CheckCenterCheckTypes_CheckTypeId",
                table: "CheckCenterSources",
                column: "CheckTypeId",
                principalTable: "CheckCenterCheckTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterStates_CheckCenterSources_SourceId",
                table: "CheckCenterStates",
                column: "SourceId",
                principalTable: "CheckCenterSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventId",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_NewStateId",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_OldStateId",
                table: "CheckCenterActionLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventId",
                table: "CheckCenterAdditionalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventId",
                table: "CheckCenterComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterCheckTypes_CheckTypeId",
                table: "CheckCenterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterSources_SourceId",
                table: "CheckCenterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterStates_StateId",
                table: "CheckCenterEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventId",
                table: "CheckCenterFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterSources_CheckCenterCheckTypes_CheckTypeId",
                table: "CheckCenterSources");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCenterStates_CheckCenterSources_SourceId",
                table: "CheckCenterStates");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "CheckCenterStates",
                newName: "SourceID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterStates",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterStates_SourceId",
                table: "CheckCenterStates",
                newName: "IX_CheckCenterStates_SourceID");

            migrationBuilder.RenameColumn(
                name: "CheckTypeId",
                table: "CheckCenterSources",
                newName: "CheckTypeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterSources",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterSources_CheckTypeId",
                table: "CheckCenterSources",
                newName: "IX_CheckCenterSources_CheckTypeID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "CheckCenterFeedback",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterFeedback",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterFeedback_EventId",
                table: "CheckCenterFeedback",
                newName: "IX_CheckCenterFeedback_EventID");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "CheckCenterEvents",
                newName: "StateID");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "CheckCenterEvents",
                newName: "SourceID");

            migrationBuilder.RenameColumn(
                name: "CheckTypeId",
                table: "CheckCenterEvents",
                newName: "CheckTypeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterEvents",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterEvents_StateId",
                table: "CheckCenterEvents",
                newName: "IX_CheckCenterEvents_StateID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterEvents_SourceId",
                table: "CheckCenterEvents",
                newName: "IX_CheckCenterEvents_SourceID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterEvents_CheckTypeId",
                table: "CheckCenterEvents",
                newName: "IX_CheckCenterEvents_CheckTypeID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "CheckCenterComments",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterComments",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterComments_EventId",
                table: "CheckCenterComments",
                newName: "IX_CheckCenterComments_EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterCheckTypes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "CheckCenterAdditionalInfo",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterAdditionalInfo",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterAdditionalInfo_EventId",
                table: "CheckCenterAdditionalInfo",
                newName: "IX_CheckCenterAdditionalInfo_EventID");

            migrationBuilder.RenameColumn(
                name: "OldStateId",
                table: "CheckCenterActionLogs",
                newName: "OldStateID");

            migrationBuilder.RenameColumn(
                name: "NewStateId",
                table: "CheckCenterActionLogs",
                newName: "NewStateID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "CheckCenterActionLogs",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckCenterActionLogs",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterActionLogs_OldStateId",
                table: "CheckCenterActionLogs",
                newName: "IX_CheckCenterActionLogs_OldStateID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterActionLogs_NewStateId",
                table: "CheckCenterActionLogs",
                newName: "IX_CheckCenterActionLogs_NewStateID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckCenterActionLogs_EventId",
                table: "CheckCenterActionLogs",
                newName: "IX_CheckCenterActionLogs_EventID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventID",
                table: "CheckCenterActionLogs",
                column: "EventID",
                principalTable: "CheckCenterEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_NewStateID",
                table: "CheckCenterActionLogs",
                column: "NewStateID",
                principalTable: "CheckCenterStates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterActionLogs_CheckCenterStates_OldStateID",
                table: "CheckCenterActionLogs",
                column: "OldStateID",
                principalTable: "CheckCenterStates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventID",
                table: "CheckCenterAdditionalInfo",
                column: "EventID",
                principalTable: "CheckCenterEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterComments_CheckCenterEvents_EventID",
                table: "CheckCenterComments",
                column: "EventID",
                principalTable: "CheckCenterEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterCheckTypes_CheckTypeID",
                table: "CheckCenterEvents",
                column: "CheckTypeID",
                principalTable: "CheckCenterCheckTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterSources_SourceID",
                table: "CheckCenterEvents",
                column: "SourceID",
                principalTable: "CheckCenterSources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterEvents_CheckCenterStates_StateID",
                table: "CheckCenterEvents",
                column: "StateID",
                principalTable: "CheckCenterStates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterFeedback_CheckCenterEvents_EventID",
                table: "CheckCenterFeedback",
                column: "EventID",
                principalTable: "CheckCenterEvents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterSources_CheckCenterCheckTypes_CheckTypeID",
                table: "CheckCenterSources",
                column: "CheckTypeID",
                principalTable: "CheckCenterCheckTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCenterStates_CheckCenterSources_SourceID",
                table: "CheckCenterStates",
                column: "SourceID",
                principalTable: "CheckCenterSources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
