using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "FoodPlaces",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "FoodPlaces",
                newName: "UpdateAt");
        }
    }
}
