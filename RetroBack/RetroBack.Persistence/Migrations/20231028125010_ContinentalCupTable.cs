using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContinentalCupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContinentalCups",
                columns: table => new
                {
                    ContinentalCupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Confederation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinnerNationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunnerUpNationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThirdPlaceNationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentalCups", x => x.ContinentalCupID);
                    table.ForeignKey(
                        name: "FK_ContinentalCupRunnerUp_Nation",
                        column: x => x.RunnerUpNationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                    table.ForeignKey(
                        name: "FK_ContinentalCupThirdPlace_Nation",
                        column: x => x.ThirdPlaceNationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                    table.ForeignKey(
                        name: "FK_ContinentalCupWinner_Nation",
                        column: x => x.WinnerNationId,
                        principalTable: "NationInfo",
                        principalColumn: "NationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContinentalCups_RunnerUpNationId",
                table: "ContinentalCups",
                column: "RunnerUpNationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContinentalCups_ThirdPlaceNationId",
                table: "ContinentalCups",
                column: "ThirdPlaceNationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContinentalCups_WinnerNationId",
                table: "ContinentalCups",
                column: "WinnerNationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContinentalCups");
        }
    }
}
