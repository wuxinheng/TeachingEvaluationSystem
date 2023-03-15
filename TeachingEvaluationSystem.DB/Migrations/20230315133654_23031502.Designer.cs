﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeachingEvaluationSystem.DB;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    [DbContext(typeof(TeachingEvaluationSystemDB))]
    [Migration("20230315133654_23031502")]
    partial class _23031502
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MenuRole", b =>
                {
                    b.Property<int>("MenusId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("MenusId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("MenuRole");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Route")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.OptionBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionBankId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("QuestionBankId");

                    b.ToTable("OptionBanks");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Tile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("QuestionBanks");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBankSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionBankId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionBankId");

                    b.HasIndex("SubjectId");

                    b.ToTable("BankSubjects");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionBankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionBankId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrossScore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserClassId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Scores")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("YearMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserAnswerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OptionBankId")
                        .HasColumnType("int");

                    b.Property<int>("OptionScores")
                        .HasColumnType("int");

                    b.Property<int>("QuestionBankId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionScores")
                        .HasColumnType("int");

                    b.Property<int>("UserAnswerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionBankId");

                    b.HasIndex("QuestionBankId");

                    b.HasIndex("UserAnswerId");

                    b.ToTable("UserAnswerDetails");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassesId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClasses");
                });

            modelBuilder.Entity("MenuRole", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.OptionBank", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.QuestionBank", "QuestionBank")
                        .WithMany("OptionBanks")
                        .HasForeignKey("QuestionBankId");

                    b.Navigation("QuestionBank");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBank", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBankSubject", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.QuestionBank", "QuestionBank")
                        .WithMany("Subjects")
                        .HasForeignKey("QuestionBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Subject", "Subject")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionBank");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Role", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.QuestionBank", null)
                        .WithMany("Roles")
                        .HasForeignKey("QuestionBankId");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Subject", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.UserClass", "UserClasses")
                        .WithMany("Subjects")
                        .HasForeignKey("UserClassId");

                    b.Navigation("UserClasses");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.User", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Class");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserAnswer", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserAnswerDetail", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.OptionBank", "OptionBank")
                        .WithMany()
                        .HasForeignKey("OptionBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.QuestionBank", "QuestionBank")
                        .WithMany()
                        .HasForeignKey("QuestionBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.UserAnswer", "UserAnswer")
                        .WithMany("AnswerDetails")
                        .HasForeignKey("UserAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OptionBank");

                    b.Navigation("QuestionBank");

                    b.Navigation("UserAnswer");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserClass", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Class", "Classes")
                        .WithMany("Teachers")
                        .HasForeignKey("ClassesId");

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.User", "User")
                        .WithMany("UserClasses")
                        .HasForeignKey("UserId");

                    b.Navigation("Classes");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Class", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBank", b =>
                {
                    b.Navigation("OptionBanks");

                    b.Navigation("Roles");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Subject", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.User", b =>
                {
                    b.Navigation("UserClasses");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserAnswer", b =>
                {
                    b.Navigation("AnswerDetails");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserClass", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
