using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContinentalCupSquads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContinentalCupSquads",
                columns: table => new
                {
                    SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    NationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentalCupSquads", x => x.SquadId);
                    table.ForeignKey(
                        name: "FK_ContinentalCupSquad_Nation",
                        column: x => x.NationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                });

            migrationBuilder.CreateTable(
                name: "NationIconStatsContinentalCupSquads",
                columns: table => new
                {
                    StatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationIconStatsContinentalCupSquads", x => new { x.SquadId, x.StatsId });
                    table.ForeignKey(
                        name: "FK_ManyToMany_ContinentalCupSquads",
                        column: x => x.SquadId,
                        principalTable: "ContinentalCupSquads",
                        principalColumn: "SquadId");
                    table.ForeignKey(
                        name: "FK_ManyToMany_NationIconStats",
                        column: x => x.StatsId,
                        principalTable: "NationIconStats",
                        principalColumn: "StatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContinentalCupSquads_NationId",
                table: "ContinentalCupSquads",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_NationIconStatsContinentalCupSquads_StatsId",
                table: "NationIconStatsContinentalCupSquads",
                column: "StatsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationIconStatsContinentalCupSquads");

            migrationBuilder.DropTable(
                name: "ContinentalCupSquads");
        }
    }
}
