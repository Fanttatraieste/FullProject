using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UEFAWinnersCupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WinnersCupInfo",
                columns: table => new
                {
                    WinnersCupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Confederation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UefaWinnersCupWinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UefaWinnersCupRunnerUpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinnersCupInfo", x => x.WinnersCupID);
                    table.ForeignKey(
                        name: "FK_UEFAWinnerCupRunnerUp_Team",
                        column: x => x.UefaWinnersCupRunnerUpId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_UEFAWinnerCupWinner_Team",
                        column: x => x.UefaWinnersCupWinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinnersCupInfo_UefaWinnersCupRunnerUpId",
                table: "WinnersCupInfo",
                column: "UefaWinnersCupRunnerUpId");

            migrationBuilder.CreateIndex(
                name: "IX_WinnersCupInfo_UefaWinnersCupWinnerId",
                table: "WinnersCupInfo",
                column: "UefaWinnersCupWinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinnersCupInfo");
        }
    }
}
