using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodPlaceReviewToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "food_place_reviews");

            migrationBuilder.RenameColumn(
                name: "review_value",
                table: "food_places",
                newName: "average_rating");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "food_place_reviews",
                newName: "comment");

            migrationBuilder.AddColumn<Guid>(
                name: "author_id",
                table: "food_place_reviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "food_place_reviews",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "ix_food_place_reviews_author_id",
                table: "food_place_reviews",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "fk_food_place_reviews_asp_net_users_author_id",
                table: "food_place_reviews",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_food_place_reviews_asp_net_users_author_id",
                table: "food_place_reviews");

            migrationBuilder.DropIndex(
                name: "ix_food_place_reviews_author_id",
                table: "food_place_reviews");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "food_place_reviews");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "food_place_reviews");

            migrationBuilder.RenameColumn(
                name: "average_rating",
                table: "food_places",
                newName: "review_value");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "food_place_reviews",
                newName: "description");

            migrationBuilder.AddColumn<float>(
                name: "rating",
                table: "food_place_reviews",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
