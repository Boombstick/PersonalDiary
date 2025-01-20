using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodPlaceReviewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "review_count",
                table: "food_places",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "review_value",
                table: "food_places",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "food_place_reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    food_rating = table.Column<byte>(type: "smallint", nullable: false),
                    vibe_rating = table.Column<byte>(type: "smallint", nullable: false),
                    service_rating = table.Column<byte>(type: "smallint", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false),
                    food_place_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_place_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_food_place_reviews_food_places_food_place_id",
                        column: x => x.food_place_id,
                        principalTable: "food_places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_food_place_reviews_food_place_id",
                table: "food_place_reviews",
                column: "food_place_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food_place_reviews");

            migrationBuilder.DropColumn(
                name: "review_count",
                table: "food_places");

            migrationBuilder.DropColumn(
                name: "review_value",
                table: "food_places");
        }
    }
}
