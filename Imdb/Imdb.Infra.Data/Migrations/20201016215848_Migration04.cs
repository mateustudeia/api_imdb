using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Data.Migrations
{
    public partial class Migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                schema: "imdb",
                table: "administrator",
                newName: "is_disabled");

            migrationBuilder.AddColumn<DateTime>(
                name: "creation_date",
                schema: "imdb",
                table: "administrator",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creation_date",
                schema: "imdb",
                table: "administrator");

            migrationBuilder.RenameColumn(
                name: "is_disabled",
                schema: "imdb",
                table: "administrator",
                newName: "IsDisabled");
        }
    }
}
