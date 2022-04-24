using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR_EduOre_api.Migrations
{
    public partial class AddUserInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    telephone = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    head_portrait = table.Column<byte[]>(type: "BLOB", nullable: false),
                    sex = table.Column<bool>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    department = table.Column<string>(type: "TEXT", nullable: false),
                    lesson = table.Column<string>(type: "TEXT", nullable: false),
                    base_role_name = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_information", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_information");
        }
    }
}
