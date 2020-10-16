using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Imdb.Infra.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vote_user_movie",
                schema: "imdb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vote_note = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_user_movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vote_user_movie_movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "imdb",
                        principalTable: "movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vote_user_movie_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "imdb",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vote_user_movie_MovieId",
                schema: "imdb",
                table: "vote_user_movie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_vote_user_movie_UserId",
                schema: "imdb",
                table: "vote_user_movie",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vote_user_movie",
                schema: "imdb");
        }
    }
}
