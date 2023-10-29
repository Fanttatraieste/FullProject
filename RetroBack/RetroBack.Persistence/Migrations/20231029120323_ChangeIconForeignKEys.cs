﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroBack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIconForeignKEys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationIconStatId",
                table: "Icons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NationIconStatId",
                table: "Icons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
