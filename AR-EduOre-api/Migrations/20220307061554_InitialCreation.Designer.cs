﻿// <auto-generated />
using System;
using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AR_EduOre_api.Migrations
{
    [DbContext(typeof(ARDbContext))]
    [Migration("20220307061554_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("AR_EduOre_api.Entities.CourseEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AR_ADDRESS_API")
                        .HasColumnType("INTEGER");

                    b.Property<string>("equipment_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("equipment_type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("if_course_equipment")
                        .HasColumnType("INTEGER");

                    b.Property<int>("offline_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("open_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("course_equipment");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.CourseTeacherProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("offline_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("online_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("open_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("teacher_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("teacher_picture")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("teacher_profile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("course_teacher_profile");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.DailyQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("if_punch_in")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("punch_in_date")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("daily_question");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.DailyQuestionBank", b =>
                {
                    b.Property<int>("DailyQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("daily_A_options")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("daily_B_options")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("daily_C_options")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("daily_D_options")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("daily_stem_description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DailyQuestionID");

                    b.ToTable("daily_question_bank");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.DiscussionQuestionBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("daily_question_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("discussion_question_analysis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("discussion_question_choice_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("discussion_question_description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("discussion_question_score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("discussion_question_bank");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.ExaminationPaperBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("examination_paper_time")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("examination_paper_bank");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.OfflineCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Offline_enroll_end_date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("offline_begin_date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("offline_course_if")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("offline_end_date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("offline_enroll_begin_date")
                        .HasColumnType("TEXT");

                    b.Property<int>("offline_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("offline_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("offline_space")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("offline_week")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("offline_course");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.OnlineCourse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("online_begin_time")
                        .HasColumnType("TEXT");

                    b.Property<bool>("online_course_if")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("online_course_status")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("online_end_time")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("online_enroll_begin_time")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("online_enroll_end_time")
                        .HasColumnType("TEXT");

                    b.Property<string>("online_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("online_picture")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte>("online_week")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("online_course");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.OnlineCourseEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("online_course_id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("online_evaluation_date")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("online_evaluation_picture")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("online_evaluation_text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("online_link")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("online_course_evaluation");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.OpenCourse", b =>
                {
                    b.Property<int>("OpenCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("open_course_link")
                        .HasColumnType("INTEGER");

                    b.Property<string>("open_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OpenCourseId");

                    b.ToTable("open_course");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.OpenCourseEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpenCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("open_evaluation_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("open_evaluation_text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("open_evalution_blob")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("open_course_evaluaton");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.QuestionChoiceBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("A_option")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("B_option")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("C_option")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("D_option")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("examinationPaperID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("questionChoiceDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("questionScore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("question_choic_analysis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("question_choice_bank");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.StudentAnswerRecord", b =>
                {
                    b.Property<int>("StudentAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("daily_question_answer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("daily_question_answer_right")
                        .HasColumnType("INTEGER");

                    b.Property<int>("daily_question_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("discussion_question_answer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("discussion_question_answer_right")
                        .HasColumnType("INTEGER");

                    b.Property<int>("discussion_question_choice_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("examination_paper_id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("finish")
                        .HasColumnType("INTEGER");

                    b.Property<string>("question_choice_answer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("question_choice_answer_right")
                        .HasColumnType("INTEGER");

                    b.Property<int>("question_choice_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentAnswerId");

                    b.ToTable("student_answer_record");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.StudentCollection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("collection_daily_question")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("collection_examination_paper")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("collection_question_choice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("collection_question_choice_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("daily_question_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("question_chocie_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("student_collection_question");
                });

            modelBuilder.Entity("AR_EduOre_api.Entities.TextInformation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TextContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("begin_Time")
                        .HasColumnType("TEXT");

                    b.Property<bool>("clock_in_Friday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_Monday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_Saturday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_Sunday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_Thursday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_Tuesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_Wednesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("clock_in_finish")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("clock_in_reminder_time")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("clock_in_time")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("end_Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("text_remark")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("text_information");
                });
#pragma warning restore 612, 618
        }
    }
}
