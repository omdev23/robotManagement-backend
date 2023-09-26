using Microsoft.EntityFrameworkCore.Migrations;

namespace RobotManagmentApi.Migrations
{
    public partial class RobotFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RobotFeatures",
                table: "Robots",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RobotFeatures",
                table: "Robots");
        }
    }
}
