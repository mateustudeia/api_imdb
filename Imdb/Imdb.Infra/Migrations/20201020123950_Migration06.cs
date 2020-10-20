using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Migrations
{
    public partial class Migration06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                schema: "imdb",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                schema: "imdb",
                table: "user",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password_salt",
                schema: "imdb",
                table: "user",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "imdb",
                table: "user",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                schema: "imdb",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password_salt",
                schema: "imdb",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "imdb",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "imdb",
                table: "user",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
