using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddCompanyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskDBModels",
                table: "UserTaskDBModels");

            migrationBuilder.RenameTable(
                name: "UserTaskDBModels",
                newName: "UserTask");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTask",
                table: "UserTask",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTask",
                table: "UserTask");

            migrationBuilder.RenameTable(
                name: "UserTask",
                newName: "UserTaskDBModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskDBModels",
                table: "UserTaskDBModels",
                column: "ID");
        }
    }
}
