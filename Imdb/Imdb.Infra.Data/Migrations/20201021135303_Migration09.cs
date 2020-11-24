using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Data.Migrations
{
    public partial class Migration09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hash",
                schema: "imdb",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password_salt",
                schema: "imdb",
                table: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
