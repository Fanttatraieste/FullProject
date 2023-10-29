using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BallonDorsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BallonDorStats",
                columns: table => new
                {
                    StatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallonDorStats", x => x.StatId);
                    table.ForeignKey(
                        name: "FK_BallonDorStat_Icon",
                        column: x => x.IconId,
                        principalTable: "Icons",
                        principalColumn: "IconId");
                });

            migrationBuilder.CreateTable(
                name: "BallonDors",
                columns: table => new
                {
                    BallonDorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WinnerIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RunnerUpIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThirdPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FourthPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FifthPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SixthPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeventhPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EigthPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NinethPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenthPlaceIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallonDors", x => x.BallonDorId);
                    table.ForeignKey(
                        name: "FK_BallonDorEigthPlace_BallonStats",
                        column: x => x.EigthPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorFifthPlace_BallonStats",
                        column: x => x.FifthPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorFourthPlace_BallonStats",
                        column: x => x.FourthPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorNinethPlace_BallonStats",
                        column: x => x.NinethPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorSecondPlace_BallonStats",
                        column: x => x.RunnerUpIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorSeventhPlace_BallonStats",
                        column: x => x.SeventhPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorSixthPlace_BallonStats",
                        column: x => x.SixthPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorTenthPlace_BallonStats",
                        column: x => x.TenthPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorThirdPlace_BallonStats",
                        column: x => x.ThirdPlaceIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                    table.ForeignKey(
                        name: "FK_BallonDorWinner_BallonStats",
                        column: x => x.WinnerIconId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                });

            migrationBuilder.CreateTable(
                name: "BallonDorNominationsStats",
                columns: table => new
                {
                    BallonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BallonStatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallonDorNominationsStats", x => new { x.BallonId, x.BallonStatId });
                    table.ForeignKey(
                        name: "FK_Nomination_BallonDor",
                        column: x => x.BallonId,
                        principalTable: "BallonDors",
                        principalColumn: "BallonDorId");
                    table.ForeignKey(
                        name: "FK_Nominations_BallonStats",
                        column: x => x.BallonStatId,
                        principalTable: "BallonDorStats",
                        principalColumn: "StatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BallonDorNominationsStats_BallonStatId",
                table: "BallonDorNominationsStats",
                column: "BallonStatId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_EigthPlaceIconId",
                table: "BallonDors",
                column: "EigthPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_FifthPlaceIconId",
                table: "BallonDors",
                column: "FifthPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_FourthPlaceIconId",
                table: "BallonDors",
                column: "FourthPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_NinethPlaceIconId",
                table: "BallonDors",
                column: "NinethPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_RunnerUpIconId",
                table: "BallonDors",
                column: "RunnerUpIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_SeventhPlaceIconId",
                table: "BallonDors",
                column: "SeventhPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_SixthPlaceIconId",
                table: "BallonDors",
                column: "SixthPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_TenthPlaceIconId",
                table: "BallonDors",
                column: "TenthPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_ThirdPlaceIconId",
                table: "BallonDors",
                column: "ThirdPlaceIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDors_WinnerIconId",
                table: "BallonDors",
                column: "WinnerIconId");

            migrationBuilder.CreateIndex(
                name: "IX_BallonDorStats_IconId",
                table: "BallonDorStats",
                column: "IconId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BallonDorNominationsStats");

            migrationBuilder.DropTable(
                name: "BallonDors");

            migrationBuilder.DropTable(
                name: "BallonDorStats");
        }
    }
}
