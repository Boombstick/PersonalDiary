using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDiary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskBoardEntityAndRenameAlldatabaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPlaces",
                table: "FoodPlaces");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tasks");

            migrationBuilder.RenameTable(
                name: "FoodPlaces",
                newName: "food_places");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tasks",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tasks",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tasks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tasks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tasks",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeadLine",
                table: "tasks",
                newName: "dead_line");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tasks",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "food_places",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "food_places",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Cousine",
                table: "food_places",
                newName: "cousine");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "food_places",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "food_places",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "food_places",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "food_places",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "food_places",
                newName: "created_at");

            migrationBuilder.AddColumn<Guid>(
                name: "board_id",
                table: "tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_tasks",
                table: "tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_food_places",
                table: "food_places",
                column: "id");

            migrationBuilder.CreateTable(
                name: "task_boards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_boards", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "task_boards",
                columns: ["id", "name"],
                values: ["00000000-0000-0000-0000-000000000000", "default"]);

            migrationBuilder.Sql(@"
                 UPDATE tasks 
                 SET board_id = '00000000-0000-0000-0000-000000000000'
                 WHERE board_id IS NULL");

            migrationBuilder.AlterColumn<Guid>(
            name: "board_id",
            table: "tasks",
            type: "uuid",
            nullable: false,
            oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_tasks_board_id",
                table: "tasks",
                column: "board_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_task_boards_board_id",
                table: "tasks",
                column: "board_id",
                principalTable: "task_boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tasks_task_boards_board_id",
                table: "tasks");

            migrationBuilder.DropTable(
                name: "task_boards");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tasks",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "ix_tasks_board_id",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_food_places",
                table: "food_places");

            migrationBuilder.DropColumn(
                name: "board_id",
                table: "tasks");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "food_places",
                newName: "FoodPlaces");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Tasks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "dead_line",
                table: "Tasks",
                newName: "DeadLine");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Tasks",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "FoodPlaces",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "FoodPlaces",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cousine",
                table: "FoodPlaces",
                newName: "Cousine");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "FoodPlaces",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "FoodPlaces",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FoodPlaces",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "FoodPlaces",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "FoodPlaces",
                newName: "CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPlaces",
                table: "FoodPlaces",
                column: "Id");
        }
    }
}
