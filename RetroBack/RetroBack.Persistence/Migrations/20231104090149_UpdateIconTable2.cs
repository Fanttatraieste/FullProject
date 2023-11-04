using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIconTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Icons",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Icons",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Icons");
        }
    }
}
