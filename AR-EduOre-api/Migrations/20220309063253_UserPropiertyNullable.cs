using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR_EduOre_api.Migrations
{
    public partial class UserPropiertyNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "lesson",
                table: "user_information",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "head_portrait",
                table: "user_information",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<string>(
                name: "department",
                table: "user_information",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte>(
                name: "base_role_name",
                table: "user_information",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "lesson",
                table: "user_information",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "head_portrait",
                table: "user_information",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "department",
                table: "user_information",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "base_role_name",
                table: "user_information",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
