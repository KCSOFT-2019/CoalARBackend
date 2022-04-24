using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR_EduOre_api.Migrations
{
    public partial class UpdateOfflineCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offline_id",
                table: "offline_course");

            migrationBuilder.AddColumn<byte[]>(
                name: "offline_picture",
                table: "offline_course",
                type: "BLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "offline_picture",
                table: "offline_course");

            migrationBuilder.AddColumn<Guid>(
                name: "offline_id",
                table: "offline_course",
                type: "TEXT",
                nullable: true);
        }
    }
}
