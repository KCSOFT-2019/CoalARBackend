using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR_EduOre_api.Migrations
{
    public partial class CourseTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teacher_name",
                table: "course_teacher_profile");

            migrationBuilder.DropColumn(
                name: "teacher_picture",
                table: "course_teacher_profile");

            migrationBuilder.DropColumn(
                name: "teacher_profile",
                table: "course_teacher_profile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "teacher_name",
                table: "course_teacher_profile",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "teacher_picture",
                table: "course_teacher_profile",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "teacher_profile",
                table: "course_teacher_profile",
                type: "TEXT",
                nullable: true);
        }
    }
}
