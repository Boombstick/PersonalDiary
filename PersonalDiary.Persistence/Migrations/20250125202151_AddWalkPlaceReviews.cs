using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWalkPlaceReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "average_rating",
                table: "walk_places",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "review_count",
                table: "walk_places",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "author_id",
                table: "culture_place_reviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "walk_places_reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vibe_rating = table.Column<byte>(type: "smallint", nullable: false),
                    walk_place_id = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_walk_places_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_walk_places_reviews_asp_net_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_walk_places_reviews_walk_places_walk_place_id",
                        column: x => x.walk_place_id,
                        principalTable: "walk_places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_culture_place_reviews_author_id",
                table: "culture_place_reviews",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_walk_places_reviews_author_id",
                table: "walk_places_reviews",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_walk_places_reviews_walk_place_id",
                table: "walk_places_reviews",
                column: "walk_place_id");

            migrationBuilder.AddForeignKey(
                name: "fk_culture_place_reviews_asp_net_users_author_id",
                table: "culture_place_reviews",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_culture_place_reviews_asp_net_users_author_id",
                table: "culture_place_reviews");

            migrationBuilder.DropTable(
                name: "walk_places_reviews");

            migrationBuilder.DropIndex(
                name: "ix_culture_place_reviews_author_id",
                table: "culture_place_reviews");

            migrationBuilder.DropColumn(
                name: "average_rating",
                table: "walk_places");

            migrationBuilder.DropColumn(
                name: "review_count",
                table: "walk_places");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "culture_place_reviews");
        }
    }
}
