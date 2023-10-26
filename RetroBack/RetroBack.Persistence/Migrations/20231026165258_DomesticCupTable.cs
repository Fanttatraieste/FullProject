using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DomesticCupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomesticCupInfo",
                columns: table => new
                {
                    DomesticCupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticCupInfo", x => x.DomesticCupID);
                    table.ForeignKey(
                        name: "FK_DomesticCup_Team",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomesticCupInfo_WinnerId",
                table: "DomesticCupInfo",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomesticCupInfo");
        }
    }
}
