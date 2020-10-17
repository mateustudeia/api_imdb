using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Migrations
{
    public partial class Migration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "education",
                schema: "imdb",
                table: "administrator",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profession",
                schema: "imdb",
                table: "administrator",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "education",
                schema: "imdb",
                table: "administrator");

            migrationBuilder.DropColumn(
                name: "profession",
                schema: "imdb",
                table: "administrator");
        }
    }
}
