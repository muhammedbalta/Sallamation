using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sallamation.Server.Migrations
{
    public partial class IdentityInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Questions");
        }
    }
}
