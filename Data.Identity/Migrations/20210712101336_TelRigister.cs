using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Identity.Migrations
{
    public partial class TelRigister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelegrammRegisterCode",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegrammRegisterCode",
                table: "AspNetUsers");
        }
    }
}
