using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addCityEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.DropColumn(
                name: "city",
                table: "food_places");

            migrationBuilder.AddColumn<long>(
                name: "city_id",
                table: "food_places",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_food_places_city_id",
                table: "food_places",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "fk_food_places_cities_city_id",
                table: "food_places",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_food_places_cities_city_id",
                table: "food_places");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropIndex(
                name: "ix_food_places_city_id",
                table: "food_places");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "food_places");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "food_places",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
