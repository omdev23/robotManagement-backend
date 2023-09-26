using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RobotManagmentApi.Migrations
{
    public partial class FirstMigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Robots",
                columns: new[] { "Id", "Date", "FirmwareVersion", "ImagePath", "Location", "OwnerName", "RobotFeatures", "RobotName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "22PQ3T", "robot.jpg", "Junagadh", "akshay", "A versatile robot designed to assist in various tasks with its advanced AI, including cleaning, cooking, and personal assistance.", "RoboMax" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23SOq4", "robot6.jpg", "Suart", "Omdev", "An innovative robot equipped with cutting-edge technology, capable of autonomous navigation and data analysis for research and surveillance", "CyberBot" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23SOW4", "robot2.jpg", "Junagadh", "Akshay", "A rugged and agile robot designed for planetary exploration, equipped with high-resolution cameras and sample collection tools.", "MechWarrior" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23SOD4", "robot3.jpg", "Suart", "Omdev", "A nimble flying robot with exceptional maneuverability, ideal for aerial photography and surveillance missions", "TitanTron" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23S5V4", "robot4.jpg", "Junagadh", "Akshay", "A medical robot with AI-driven diagnostics, capable of assisting in surgeries and patient care in hospitals.", "GalaxyBots" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23S6X4", "robot5.jpg", "Suart", "Omdev", "An agricultural robot designed to automate farming tasks, including planting, watering, and harvesting crops.", "NanoDroid" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");
        }
    }
}
