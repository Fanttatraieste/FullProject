using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TeamIconStatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamIconStats",
                columns: table => new
                {
                    StatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayedFromYear = table.Column<int>(type: "int", nullable: false),
                    PlayedUntilYear = table.Column<int>(type: "int", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamIconStats", x => x.StatId);
                    table.ForeignKey(
                        name: "FK_IconStat_Icon",
                        column: x => x.IconId,
                        principalTable: "Icons",
                        principalColumn: "IconId");
                    table.ForeignKey(
                        name: "FK_IconStats_Team",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamIconStats_IconId",
                table: "TeamIconStats",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamIconStats_TeamId",
                table: "TeamIconStats",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamIconStats");
        }
    }
}
