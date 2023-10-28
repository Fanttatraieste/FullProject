using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WorldCupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorldCups",
                columns: table => new
                {
                    WorldCupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WinnerNationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunnerUpNationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThirdPlaceNationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldCups", x => x.WorldCupID);
                    table.ForeignKey(
                        name: "FK_WorldCupRunnerUp_Nation",
                        column: x => x.RunnerUpNationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                    table.ForeignKey(
                        name: "FK_WorldCupThirdPlace_Nation",
                        column: x => x.ThirdPlaceNationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                    table.ForeignKey(
                        name: "FK_WorldCupWinner_Nation",
                        column: x => x.WinnerNationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorldCups_RunnerUpNationId",
                table: "WorldCups",
                column: "RunnerUpNationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldCups_ThirdPlaceNationId",
                table: "WorldCups",
                column: "ThirdPlaceNationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldCups_WinnerNationId",
                table: "WorldCups",
                column: "WinnerNationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorldCups");
        }
    }
}
