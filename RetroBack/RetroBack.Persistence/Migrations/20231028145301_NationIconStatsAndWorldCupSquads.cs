using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NationIconStatsAndWorldCupSquads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NationIconStatId",
                table: "Icons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "NationIconStats",
                columns: table => new
                {
                    StatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false),
                    WorldCupGoals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationIconStats", x => x.StatId);
                    table.ForeignKey(
                        name: "FK_NationStats_Icon",
                        column: x => x.IconId,
                        principalTable: "Icons",
                        principalColumn: "IconId");
                    table.ForeignKey(
                        name: "FK_NationStats_Nation",
                        column: x => x.NationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                });

            migrationBuilder.CreateTable(
                name: "WorldCupSquads",
                columns: table => new
                {
                    SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldCupSquads", x => x.SquadId);
                    table.ForeignKey(
                        name: "FK_WorldCupSquad_Nation",
                        column: x => x.NationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                });

            migrationBuilder.CreateTable(
                name: "NationIconStatsWorldCupSquads",
                columns: table => new
                {
                    StatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationIconStatsWorldCupSquads", x => new { x.StatsId, x.SquadId });
                    table.ForeignKey(
                        name: "FK_ManyToMany_NationStats",
                        column: x => x.StatsId,
                        principalTable: "NationIconStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_ManyToMany_WorldCupSquads",
                        column: x => x.SquadId,
                        principalTable: "WorldCupSquads",
                        principalColumn: "SquadId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NationIconStats_IconId",
                table: "NationIconStats",
                column: "IconId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NationIconStats_NationId",
                table: "NationIconStats",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_NationIconStatsWorldCupSquads_SquadId",
                table: "NationIconStatsWorldCupSquads",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldCupSquads_NationId",
                table: "WorldCupSquads",
                column: "NationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationIconStatsWorldCupSquads");

            migrationBuilder.DropTable(
                name: "NationIconStats");

            migrationBuilder.DropTable(
                name: "WorldCupSquads");

            migrationBuilder.DropColumn(
                name: "NationIconStatId",
                table: "Icons");
        }
    }
}
