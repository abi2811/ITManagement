using Microsoft.EntityFrameworkCore.Migrations;

namespace ITManagement.Api.Migrations
{
    public partial class InitAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Users",
                nullable: true);
        }
    }
}
