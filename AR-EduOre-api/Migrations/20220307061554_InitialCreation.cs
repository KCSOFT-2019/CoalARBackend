using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR_EduOre_api.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course_equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    open_id = table.Column<int>(type: "INTEGER", nullable: false),
                    offline_id = table.Column<int>(type: "INTEGER", nullable: false),
                    if_course_equipment = table.Column<bool>(type: "INTEGER", nullable: false),
                    equipment_name = table.Column<string>(type: "TEXT", nullable: false),
                    equipment_type = table.Column<string>(type: "TEXT", nullable: false),
                    AR_ADDRESS_API = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course_teacher_profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    online_id = table.Column<int>(type: "INTEGER", nullable: false),
                    open_id = table.Column<int>(type: "INTEGER", nullable: false),
                    offline_id = table.Column<int>(type: "INTEGER", nullable: false),
                    teacher_name = table.Column<string>(type: "TEXT", nullable: false),
                    teacher_profile = table.Column<string>(type: "TEXT", nullable: false),
                    teacher_picture = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_teacher_profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "daily_question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    punch_in_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    if_punch_in = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daily_question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "daily_question_bank",
                columns: table => new
                {
                    DailyQuestionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    daily_stem_description = table.Column<string>(type: "TEXT", nullable: false),
                    daily_A_options = table.Column<string>(type: "TEXT", nullable: false),
                    daily_B_options = table.Column<string>(type: "TEXT", nullable: false),
                    daily_C_options = table.Column<string>(type: "TEXT", nullable: false),
                    daily_D_options = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daily_question_bank", x => x.DailyQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "discussion_question_bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    daily_question_id = table.Column<int>(type: "INTEGER", nullable: false),
                    discussion_question_choice_id = table.Column<int>(type: "INTEGER", nullable: false),
                    discussion_question_score = table.Column<byte>(type: "INTEGER", nullable: false),
                    discussion_question_description = table.Column<string>(type: "TEXT", nullable: false),
                    discussion_question_analysis = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discussion_question_bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "examination_paper_bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    examination_paper_time = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examination_paper_bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "offline_course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    offline_id = table.Column<int>(type: "INTEGER", nullable: false),
                    offline_name = table.Column<string>(type: "TEXT", nullable: false),
                    offline_begin_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    offline_end_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    offline_week = table.Column<byte>(type: "INTEGER", nullable: false),
                    offline_space = table.Column<string>(type: "TEXT", nullable: false),
                    offline_enroll_begin_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Offline_enroll_end_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    offline_course_if = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offline_course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "online_course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    online_name = table.Column<string>(type: "TEXT", nullable: false),
                    online_picture = table.Column<byte[]>(type: "BLOB", nullable: false),
                    online_begin_time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    online_end_time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    online_week = table.Column<byte>(type: "INTEGER", nullable: false),
                    online_enroll_begin_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    online_enroll_end_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    online_course_if = table.Column<bool>(type: "INTEGER", nullable: false),
                    online_course_status = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_online_course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "online_course_evaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    online_course_id = table.Column<int>(type: "INTEGER", nullable: false),
                    online_evaluation_text = table.Column<string>(type: "TEXT", nullable: false),
                    online_evaluation_picture = table.Column<byte[]>(type: "BLOB", nullable: false),
                    online_evaluation_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    online_link = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_online_course_evaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "open_course",
                columns: table => new
                {
                    OpenCourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    open_name = table.Column<string>(type: "TEXT", nullable: false),
                    open_course_link = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_open_course", x => x.OpenCourseId);
                });

            migrationBuilder.CreateTable(
                name: "open_course_evaluaton",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OpenCourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    open_evaluation_text = table.Column<string>(type: "TEXT", nullable: false),
                    open_evalution_blob = table.Column<byte[]>(type: "BLOB", nullable: false),
                    open_evaluation_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_open_course_evaluaton", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "question_choice_bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    examinationPaperID = table.Column<int>(type: "INTEGER", nullable: false),
                    questionScore = table.Column<byte>(type: "INTEGER", nullable: false),
                    questionChoiceDescription = table.Column<string>(type: "TEXT", nullable: false),
                    A_option = table.Column<string>(type: "TEXT", nullable: false),
                    B_option = table.Column<string>(type: "TEXT", nullable: false),
                    C_option = table.Column<string>(type: "TEXT", nullable: false),
                    D_option = table.Column<string>(type: "TEXT", nullable: false),
                    question_choic_analysis = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_choice_bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student_answer_record",
                columns: table => new
                {
                    StudentAnswerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    daily_question_id = table.Column<int>(type: "INTEGER", nullable: false),
                    daily_question_answer = table.Column<string>(type: "TEXT", nullable: false),
                    daily_question_answer_right = table.Column<bool>(type: "INTEGER", nullable: false),
                    examination_paper_id = table.Column<int>(type: "INTEGER", nullable: false),
                    finish = table.Column<bool>(type: "INTEGER", nullable: false),
                    question_choice_id = table.Column<int>(type: "INTEGER", nullable: false),
                    question_choice_answer = table.Column<string>(type: "TEXT", nullable: false),
                    question_choice_answer_right = table.Column<bool>(type: "INTEGER", nullable: false),
                    discussion_question_choice_id = table.Column<int>(type: "INTEGER", nullable: false),
                    discussion_question_answer = table.Column<string>(type: "TEXT", nullable: false),
                    discussion_question_answer_right = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_answer_record", x => x.StudentAnswerId);
                });

            migrationBuilder.CreateTable(
                name: "student_collection_question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    question_chocie_id = table.Column<int>(type: "INTEGER", nullable: false),
                    collection_question_choice = table.Column<bool>(type: "INTEGER", nullable: false),
                    collection_question_choice_id = table.Column<int>(type: "INTEGER", nullable: false),
                    collection_examination_paper = table.Column<bool>(type: "INTEGER", nullable: false),
                    daily_question_id = table.Column<int>(type: "INTEGER", nullable: false),
                    collection_daily_question = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_collection_question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "text_information",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TextContent = table.Column<string>(type: "TEXT", nullable: false),
                    begin_Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    clock_in_time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    clock_in_reminder_time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    clock_in_Monday = table.Column<bool>(type: "INTEGER", nullable: false),
                    clock_in_Tuesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    clock_in_Wednesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    clock_in_Thursday = table.Column<bool>(type: "INTEGER", nullable: false),
                    clock_in_Friday = table.Column<bool>(type: "INTEGER", nullable: false),
                    clock_in_Saturday = table.Column<bool>(type: "INTEGER", nullable: false),
                    clock_in_Sunday = table.Column<bool>(type: "INTEGER", nullable: false),
                    text_remark = table.Column<string>(type: "TEXT", nullable: false),
                    clock_in_finish = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_text_information", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_equipment");

            migrationBuilder.DropTable(
                name: "course_teacher_profile");

            migrationBuilder.DropTable(
                name: "daily_question");

            migrationBuilder.DropTable(
                name: "daily_question_bank");

            migrationBuilder.DropTable(
                name: "discussion_question_bank");

            migrationBuilder.DropTable(
                name: "examination_paper_bank");

            migrationBuilder.DropTable(
                name: "offline_course");

            migrationBuilder.DropTable(
                name: "online_course");

            migrationBuilder.DropTable(
                name: "online_course_evaluation");

            migrationBuilder.DropTable(
                name: "open_course");

            migrationBuilder.DropTable(
                name: "open_course_evaluaton");

            migrationBuilder.DropTable(
                name: "question_choice_bank");

            migrationBuilder.DropTable(
                name: "student_answer_record");

            migrationBuilder.DropTable(
                name: "student_collection_question");

            migrationBuilder.DropTable(
                name: "text_information");
        }
    }
}
