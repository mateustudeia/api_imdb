using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Imdb.Infra.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movie",
                schema: "imdb");
        }
    }
}
