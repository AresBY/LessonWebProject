using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addAdKufarIDfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdKufarID",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdKufarID",
                table: "Ads");
        }
    }
}
