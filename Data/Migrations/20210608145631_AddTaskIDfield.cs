using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddTaskIDfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasBeenSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");
        }
    }
}
