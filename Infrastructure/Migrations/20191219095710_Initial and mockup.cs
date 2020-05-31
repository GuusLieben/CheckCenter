using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initialandmockup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckCenterCheckTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterCheckTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterSources",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: false),
                    SourceSeverity = table.Column<int>(nullable: false),
                    ConnectionString = table.Column<string>(maxLength: 1000, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    LogActionMandatory = table.Column<bool>(nullable: false),
                    ComebackDelay = table.Column<int>(nullable: false),
                    CheckCenterServiceId = table.Column<int>(nullable: false),
                    IsStacked = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    IsCustomerSource = table.Column<bool>(nullable: false),
                    CheckTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterSources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterSources_CheckCenterCheckTypes_CheckTypeID",
                        column: x => x.CheckTypeID,
                        principalTable: "CheckCenterCheckTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterStates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SourceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterStates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterStates_CheckCenterSources_SourceID",
                        column: x => x.SourceID,
                        principalTable: "CheckCenterSources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<DateTime>(nullable: false),
                    Finished = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    EventSeverity = table.Column<int>(nullable: false),
                    Shorthand = table.Column<string>(nullable: false),
                    SourceID = table.Column<int>(nullable: false),
                    StateID = table.Column<int>(nullable: false),
                    CheckTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterEvents_CheckCenterCheckTypes_CheckTypeID",
                        column: x => x.CheckTypeID,
                        principalTable: "CheckCenterCheckTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckCenterEvents_CheckCenterSources_SourceID",
                        column: x => x.SourceID,
                        principalTable: "CheckCenterSources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckCenterEvents_CheckCenterStates_StateID",
                        column: x => x.StateID,
                        principalTable: "CheckCenterStates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterActionLogs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    OldStateID = table.Column<int>(nullable: true),
                    NewStateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterActionLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterActionLogs_CheckCenterEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "CheckCenterEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckCenterActionLogs_CheckCenterStates_NewStateID",
                        column: x => x.NewStateID,
                        principalTable: "CheckCenterStates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckCenterActionLogs_CheckCenterStates_OldStateID",
                        column: x => x.OldStateID,
                        principalTable: "CheckCenterStates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterAdditionalInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterAdditionalInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterAdditionalInfo_CheckCenterEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "CheckCenterEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    UserEmail = table.Column<string>(maxLength: 255, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterComments_CheckCenterEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "CheckCenterEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckCenterFeedback",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    UserEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCenterFeedback", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckCenterFeedback_CheckCenterEvents_EventID",
                        column: x => x.EventID,
                        principalTable: "CheckCenterEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CheckCenterCheckTypes",
                columns: new[] { "ID", "Description", "Title" },
                values: new object[] { 1, "An AX instance type", "AXInstance" });

            migrationBuilder.InsertData(
                table: "CheckCenterSources",
                columns: new[] { "ID", "Active", "CheckCenterServiceId", "CheckTypeID", "Color", "ComebackDelay", "ConnectionString", "DisplayName", "IsCustomerSource", "IsStacked", "LogActionMandatory", "Order", "SourceSeverity" },
                values: new object[] { 4, true, 110, 1, "Yellow", 5000, "msssql://sample", "AX Amsterdam", true, true, false, 550, 500 });

            migrationBuilder.InsertData(
                table: "CheckCenterStates",
                columns: new[] { "ID", "Description", "SourceID", "Title" },
                values: new object[] { 2, "Issue is under investigation", 4, "Under investigation" });

            migrationBuilder.InsertData(
                table: "CheckCenterStates",
                columns: new[] { "ID", "Description", "SourceID", "Title" },
                values: new object[] { 3, "Issue has been resolved", 4, "Resolved" });

            migrationBuilder.InsertData(
                table: "CheckCenterEvents",
                columns: new[] { "ID", "Added", "CheckTypeID", "Description", "EventSeverity", "Finished", "Removed", "Shorthand", "SourceID", "StateID", "Title" },
                values: new object[] { 5, new DateTime(2019, 12, 19, 10, 57, 9, 402, DateTimeKind.Local).AddTicks(3010), 1, "Amsterdam has no supporters", 300, new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(3904), new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(4883), "Event1 unique identifier", 4, 2, "AXAmsterdamn No Tickets" });

            migrationBuilder.InsertData(
                table: "CheckCenterActionLogs",
                columns: new[] { "ID", "Created", "EventID", "NewStateID", "OldStateID", "UserEmail" },
                values: new object[,]
                {
                    { 6, new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(6627), 5, 2, null, "tvw203@gmail.com" },
                    { 7, new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(8283), 5, 3, 2, "tvw203@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterAdditionalInfo",
                columns: new[] { "ID", "EventID", "Key", "Value" },
                values: new object[,]
                {
                    { 12, 5, "Amount of tickets", "0" },
                    { 13, 5, "Location", "Amsterdam" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterComments",
                columns: new[] { "ID", "Content", "Created", "EventID", "UserEmail" },
                values: new object[,]
                {
                    { 10, "Ignore this check", new DateTime(2019, 12, 19, 10, 57, 9, 406, DateTimeKind.Local).AddTicks(444), 5, "tvw203@gmail.com" },
                    { 11, "Nevermind", new DateTime(2019, 12, 19, 10, 57, 9, 406, DateTimeKind.Local).AddTicks(452), 5, "tvw203@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CheckCenterFeedback",
                columns: new[] { "ID", "Content", "Created", "EventID", "UserEmail" },
                values: new object[,]
                {
                    { 8, "You forgot something", new DateTime(2019, 12, 19, 10, 57, 9, 405, DateTimeKind.Local).AddTicks(9384), 5, "tvw203@gmail.com" },
                    { 9, "You didn't do it right", new DateTime(2019, 12, 19, 10, 57, 9, 406, DateTimeKind.Local).AddTicks(412), 5, "iemand@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterActionLogs_EventID",
                table: "CheckCenterActionLogs",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterActionLogs_NewStateID",
                table: "CheckCenterActionLogs",
                column: "NewStateID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterActionLogs_OldStateID",
                table: "CheckCenterActionLogs",
                column: "OldStateID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterAdditionalInfo_EventID",
                table: "CheckCenterAdditionalInfo",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterComments_EventID",
                table: "CheckCenterComments",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterEvents_CheckTypeID",
                table: "CheckCenterEvents",
                column: "CheckTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterEvents_SourceID",
                table: "CheckCenterEvents",
                column: "SourceID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterEvents_StateID",
                table: "CheckCenterEvents",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterFeedback_EventID",
                table: "CheckCenterFeedback",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterSources_CheckTypeID",
                table: "CheckCenterSources",
                column: "CheckTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCenterStates_SourceID",
                table: "CheckCenterStates",
                column: "SourceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckCenterActionLogs");

            migrationBuilder.DropTable(
                name: "CheckCenterAdditionalInfo");

            migrationBuilder.DropTable(
                name: "CheckCenterComments");

            migrationBuilder.DropTable(
                name: "CheckCenterFeedback");

            migrationBuilder.DropTable(
                name: "CheckCenterEvents");

            migrationBuilder.DropTable(
                name: "CheckCenterStates");

            migrationBuilder.DropTable(
                name: "CheckCenterSources");

            migrationBuilder.DropTable(
                name: "CheckCenterCheckTypes");
        }
    }
}
