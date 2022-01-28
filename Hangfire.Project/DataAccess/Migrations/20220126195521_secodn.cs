using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class secodn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemInfo",
                table: "SystemInfo");

            migrationBuilder.RenameTable(
                name: "SystemInfo",
                newName: "SystemInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemInformations",
                table: "SystemInformations",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Newsletter = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemInformations",
                table: "SystemInformations");

            migrationBuilder.RenameTable(
                name: "SystemInformations",
                newName: "SystemInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemInfo",
                table: "SystemInfo",
                column: "ID");
        }
    }
}
