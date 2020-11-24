using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Data.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieId",
                schema: "imdb",
                table: "vote_user_movie");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "imdb",
                table: "vote_user_movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                schema: "imdb",
                table: "vote_user_movie",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "imdb",
                table: "vote_user_movie",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
