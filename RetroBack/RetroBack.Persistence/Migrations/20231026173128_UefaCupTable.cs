using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UefaCupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UEFACupInfo",
                columns: table => new
                {
                    UEFACupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Confederation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UefaCupWinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UefaCupRunnerUpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UEFACupInfo", x => x.UEFACupID);
                    table.ForeignKey(
                        name: "FK_UEFACupRunnerUp_Team",
                        column: x => x.UefaCupRunnerUpId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_UEFACupWinner_Team",
                        column: x => x.UefaCupWinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UEFACupInfo_UefaCupRunnerUpId",
                table: "UEFACupInfo",
                column: "UefaCupRunnerUpId");

            migrationBuilder.CreateIndex(
                name: "IX_UEFACupInfo_UefaCupWinnerId",
                table: "UEFACupInfo",
                column: "UefaCupWinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UEFACupInfo");
        }
    }
}
