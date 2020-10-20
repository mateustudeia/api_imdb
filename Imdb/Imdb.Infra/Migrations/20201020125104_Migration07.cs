using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Migrations
{
    public partial class Migration07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "imdb",
                table: "user",
                newName: "role");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                schema: "imdb",
                table: "user",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                schema: "imdb",
                table: "user",
                newName: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "imdb",
                table: "user",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }
    }
}
