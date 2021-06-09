using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class renameKufarIDfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdKufarID",
                table: "Ads",
                newName: "KufarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KufarID",
                table: "Ads",
                newName: "AdKufarID");
        }
    }
}
