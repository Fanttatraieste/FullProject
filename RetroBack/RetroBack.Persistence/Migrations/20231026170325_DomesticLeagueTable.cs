using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DomesticLeagueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomesticLeagueInfo",
                columns: table => new
                {
                    DomesticLeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunnerUpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticLeagueInfo", x => x.DomesticLeagueID);
                    table.ForeignKey(
                        name: "FK_DomesticLeagueRunnerUp_Team",
                        column: x => x.RunnerUpId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_DomesticLeagueWinner_Team",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomesticLeagueInfo_RunnerUpId",
                table: "DomesticLeagueInfo",
                column: "RunnerUpId");

            migrationBuilder.CreateIndex(
                name: "IX_DomesticLeagueInfo_WinnerId",
                table: "DomesticLeagueInfo",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomesticLeagueInfo");
        }
    }
}
