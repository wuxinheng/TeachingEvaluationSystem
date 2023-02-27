﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeachingEvaluationSystem.DB;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    [DbContext(typeof(TeachingEvaluationSystemDB))]
    [Migration("20230227070151_23022702")]
    partial class _23022702
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MenuRole", b =>
                {
                    b.Property<int>("MenusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RolesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MenusId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("MenuRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoleId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Route")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.OptionBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionBankId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionBankId");

                    b.ToTable("OptionBanks");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("QuestionBanks");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.UserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OptionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserAnswers");
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

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.OptionBank", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.QuestionBank", "QuestionBank")
                        .WithMany("OptionBanks")
                        .HasForeignKey("QuestionBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionBank");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBank", b =>
                {
                    b.HasOne("TeachingEvaluationSystem.DB.Entitys.Role", null)
                        .WithMany("QuestionBanks")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.QuestionBank", b =>
                {
                    b.Navigation("OptionBanks");
                });

            modelBuilder.Entity("TeachingEvaluationSystem.DB.Entitys.Role", b =>
                {
                    b.Navigation("QuestionBanks");
                });
#pragma warning restore 612, 618
        }
    }
}
