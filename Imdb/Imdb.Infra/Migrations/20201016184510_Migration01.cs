using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Imdb.Infra.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "imdb");

            migrationBuilder.CreateTable(
                name: "movie",
                schema: "imdb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    ano = table.Column<int>(nullable: false),
                    tempo_duracao = table.Column<TimeSpan>(type: "interval", nullable: false),
                    enredo = table.Column<string>(nullable: false),
                    diretor = table.Column<string>(nullable: false),
                    genero = table.Column<string>(nullable: false),
                    atores = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "imdb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    gender = table.Column<string>(type: "varchar(20)", nullable: true),
                    date_of_birth = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "varchar(100)", nullable: false),
                    is_deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vote_user_movie",
                schema: "imdb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vote_score = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    movie_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote_user_movie", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_user_movie_movie_movie_id",
                        column: x => x.movie_id,
                        principalSchema: "imdb",
                        principalTable: "movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vote_user_movie_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "imdb",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vote_user_movie_movie_id",
                schema: "imdb",
                table: "vote_user_movie",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_user_movie_user_id",
                schema: "imdb",
                table: "vote_user_movie",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vote_user_movie",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "movie",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "user",
                schema: "imdb");
        }
    }
}
