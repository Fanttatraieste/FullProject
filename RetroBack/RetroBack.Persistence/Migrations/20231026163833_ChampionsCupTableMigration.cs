using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChampionsCupTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampionsCupInfo",
                columns: table => new
                {
                    ChampionsCupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WinnerTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunnerUpTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsCupInfo", x => x.ChampionsCupID);
                    table.ForeignKey(
                        name: "FK_ChampionsCupRunnerUps_Team",
                        column: x => x.RunnerUpTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_ChampionsCup_Team",
                        column: x => x.WinnerTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsCupInfo_RunnerUpTeamId",
                table: "ChampionsCupInfo",
                column: "RunnerUpTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsCupInfo_WinnerTeamId",
                table: "ChampionsCupInfo",
                column: "WinnerTeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionsCupInfo");
        }
    }
}
