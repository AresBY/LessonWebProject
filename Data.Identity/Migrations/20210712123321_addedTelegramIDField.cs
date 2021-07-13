using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class addedTelegramIDField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TelegramUserID",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramUserID",
                table: "AspNetUsers");
        }
    }
}
