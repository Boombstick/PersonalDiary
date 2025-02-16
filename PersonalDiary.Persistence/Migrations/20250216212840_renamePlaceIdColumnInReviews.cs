using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class renamePlaceIdColumnInReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_culture_place_reviews_culture_places_culture_place_id",
                table: "culture_place_reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_food_place_reviews_food_places_food_place_id",
                table: "food_place_reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_walk_places_reviews_walk_places_walk_place_id",
                table: "walk_places_reviews");

            migrationBuilder.RenameColumn(
                name: "walk_place_id",
                table: "walk_places_reviews",
                newName: "place_id");

            migrationBuilder.RenameIndex(
                name: "ix_walk_places_reviews_walk_place_id",
                table: "walk_places_reviews",
                newName: "ix_walk_places_reviews_place_id");

            migrationBuilder.RenameColumn(
                name: "food_place_id",
                table: "food_place_reviews",
                newName: "place_id");

            migrationBuilder.RenameIndex(
                name: "ix_food_place_reviews_food_place_id",
                table: "food_place_reviews",
                newName: "ix_food_place_reviews_place_id");

            migrationBuilder.RenameColumn(
                name: "culture_place_id",
                table: "culture_place_reviews",
                newName: "place_id");

            migrationBuilder.RenameIndex(
                name: "ix_culture_place_reviews_culture_place_id",
                table: "culture_place_reviews",
                newName: "ix_culture_place_reviews_place_id");

            migrationBuilder.AddColumn<byte>(
                name: "interesting_rating",
                table: "culture_place_reviews",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "vibe_rating",
                table: "culture_place_reviews",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "fk_culture_place_reviews_culture_places_place_id",
                table: "culture_place_reviews",
                column: "place_id",
                principalTable: "culture_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_food_place_reviews_food_places_place_id",
                table: "food_place_reviews",
                column: "place_id",
                principalTable: "food_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_walk_places_reviews_walk_places_place_id",
                table: "walk_places_reviews",
                column: "place_id",
                principalTable: "walk_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_culture_place_reviews_culture_places_place_id",
                table: "culture_place_reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_food_place_reviews_food_places_place_id",
                table: "food_place_reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_walk_places_reviews_walk_places_place_id",
                table: "walk_places_reviews");

            migrationBuilder.DropColumn(
                name: "interesting_rating",
                table: "culture_place_reviews");

            migrationBuilder.DropColumn(
                name: "vibe_rating",
                table: "culture_place_reviews");

            migrationBuilder.RenameColumn(
                name: "place_id",
                table: "walk_places_reviews",
                newName: "walk_place_id");

            migrationBuilder.RenameIndex(
                name: "ix_walk_places_reviews_place_id",
                table: "walk_places_reviews",
                newName: "ix_walk_places_reviews_walk_place_id");

            migrationBuilder.RenameColumn(
                name: "place_id",
                table: "food_place_reviews",
                newName: "food_place_id");

            migrationBuilder.RenameIndex(
                name: "ix_food_place_reviews_place_id",
                table: "food_place_reviews",
                newName: "ix_food_place_reviews_food_place_id");

            migrationBuilder.RenameColumn(
                name: "place_id",
                table: "culture_place_reviews",
                newName: "culture_place_id");

            migrationBuilder.RenameIndex(
                name: "ix_culture_place_reviews_place_id",
                table: "culture_place_reviews",
                newName: "ix_culture_place_reviews_culture_place_id");

            migrationBuilder.AddForeignKey(
                name: "fk_culture_place_reviews_culture_places_culture_place_id",
                table: "culture_place_reviews",
                column: "culture_place_id",
                principalTable: "culture_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_food_place_reviews_food_places_food_place_id",
                table: "food_place_reviews",
                column: "food_place_id",
                principalTable: "food_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_walk_places_reviews_walk_places_walk_place_id",
                table: "walk_places_reviews",
                column: "walk_place_id",
                principalTable: "walk_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
