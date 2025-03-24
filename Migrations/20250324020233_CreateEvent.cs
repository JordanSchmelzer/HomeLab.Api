using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeLab.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_game_Events",
                table: "game_Events");

            migrationBuilder.RenameTable(
                name: "game_Events",
                newName: "GameEvents");

            migrationBuilder.AlterColumn<string>(
                name: "Winner",
                table: "Game",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Player",
                table: "Game",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "GameType",
                table: "Game",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameEvents",
                table: "GameEvents",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameEvents",
                table: "GameEvents");

            migrationBuilder.RenameTable(
                name: "GameEvents",
                newName: "game_Events");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Winner",
                keyValue: null,
                column: "Winner",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Winner",
                table: "Game",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Player",
                keyValue: null,
                column: "Player",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Player",
                table: "Game",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "GameType",
                keyValue: null,
                column: "GameType",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "GameType",
                table: "Game",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_game_Events",
                table: "game_Events",
                column: "Id");
        }
    }
}
