using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imdb.Infra.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "password_hash",
                schema: "imdb",
                table: "user",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                schema: "imdb",
                table: "user",
                nullable: false,
                defaultValue: new byte[] {  });
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
        }
    }
}
