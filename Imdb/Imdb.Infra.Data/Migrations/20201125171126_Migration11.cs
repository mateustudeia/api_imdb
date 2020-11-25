using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Imdb.Infra.Data.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_vote_user_movie",
                schema: "imdb",
                table: "vote_user_movie");

            migrationBuilder.DropIndex(
                name: "IX_vote_user_movie_movie_id",
                schema: "imdb",
                table: "vote_user_movie");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "imdb",
                table: "vote_user_movie",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vote_user_movie",
                schema: "imdb",
                table: "vote_user_movie",
                columns: new[] { "movie_id", "user_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_vote_user_movie",
                schema: "imdb",
                table: "vote_user_movie");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "imdb",
                table: "vote_user_movie",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vote_user_movie",
                schema: "imdb",
                table: "vote_user_movie",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_user_movie_movie_id",
                schema: "imdb",
                table: "vote_user_movie",
                column: "movie_id");
        }
    }
}
