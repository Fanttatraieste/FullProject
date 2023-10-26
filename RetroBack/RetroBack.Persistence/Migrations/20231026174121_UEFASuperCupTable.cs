using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UEFASuperCupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UEFASuperCupInfo",
                columns: table => new
                {
                    UEFASuperCupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confederation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    UefaSuperCupWinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UEFASuperCupInfo", x => x.UEFASuperCupID);
                    table.ForeignKey(
                        name: "FK_UEFASuperCupRunnerUp_Team",
                        column: x => x.UefaSuperCupWinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UEFASuperCupInfo_UefaSuperCupWinnerId",
                table: "UEFASuperCupInfo",
                column: "UefaSuperCupWinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UEFASuperCupInfo");
        }
    }
}
