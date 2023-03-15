//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace TeachingEvaluationSystem.DB.Migrations
//{
//    /// <inheritdoc />
//    public partial class _23030801 : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Classes",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Classes", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Menus",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Menus", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "QuestionType",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Weight = table.Column<double>(type: "float", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_QuestionType", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "QuestionBanks",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Tile = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    QuestionTypeId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_QuestionBanks", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_QuestionBanks_QuestionType_QuestionTypeId",
//                        column: x => x.QuestionTypeId,
//                        principalTable: "QuestionType",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "OptionBanks",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    QuestionBankId = table.Column<int>(type: "int", nullable: true),
//                    Weight = table.Column<double>(type: "float", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_OptionBanks", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_OptionBanks_QuestionBanks_QuestionBankId",
//                        column: x => x.QuestionBankId,
//                        principalTable: "QuestionBanks",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Roles",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    QuestionBankId = table.Column<int>(type: "int", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Roles", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Roles_QuestionBanks_QuestionBankId",
//                        column: x => x.QuestionBankId,
//                        principalTable: "QuestionBanks",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "MenuRole",
//                columns: table => new
//                {
//                    MenusId = table.Column<int>(type: "int", nullable: false),
//                    RolesId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_MenuRole", x => new { x.MenusId, x.RolesId });
//                    table.ForeignKey(
//                        name: "FK_MenuRole_Menus_MenusId",
//                        column: x => x.MenusId,
//                        principalTable: "Menus",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_MenuRole_Roles_RolesId",
//                        column: x => x.RolesId,
//                        principalTable: "Roles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Users",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    RoleId = table.Column<int>(type: "int", nullable: true),
//                    ClassId = table.Column<int>(type: "int", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Users", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Users_Classes_ClassId",
//                        column: x => x.ClassId,
//                        principalTable: "Classes",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_Users_Roles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "Roles",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "UserClasses",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    ClassesId = table.Column<int>(type: "int", nullable: true),
//                    UserId = table.Column<int>(type: "int", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_UserClasses", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_UserClasses_Classes_ClassesId",
//                        column: x => x.ClassesId,
//                        principalTable: "Classes",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK_UserClasses_Users_UserId",
//                        column: x => x.UserId,
//                        principalTable: "Users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Subjects",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    GrossScore = table.Column<int>(type: "int", nullable: false),
//                    UserClassId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Subjects", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Subjects_UserClasses_UserClassId",
//                        column: x => x.UserClassId,
//                        principalTable: "UserClasses",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "BankSubjects",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    SubjectId = table.Column<int>(type: "int", nullable: false),
//                    QuestionBankId = table.Column<int>(type: "int", nullable: false),
//                    Score = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_BankSubjects", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_BankSubjects_QuestionBanks_QuestionBankId",
//                        column: x => x.QuestionBankId,
//                        principalTable: "QuestionBanks",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_BankSubjects_Subjects_SubjectId",
//                        column: x => x.SubjectId,
//                        principalTable: "Subjects",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "UserAnswers",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    StudentId = table.Column<int>(type: "int", nullable: false),
//                    TeacherId = table.Column<int>(type: "int", nullable: false),
//                    SubjectId = table.Column<int>(type: "int", nullable: false),
//                    ClassId = table.Column<int>(type: "int", nullable: false),
//                    Scores = table.Column<int>(type: "int", nullable: false),
//                    YearMonth = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_UserAnswers_Classes_ClassId",
//                        column: x => x.ClassId,
//                        principalTable: "Classes",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_UserAnswers_Subjects_SubjectId",
//                        column: x => x.SubjectId,
//                        principalTable: "Subjects",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_UserAnswers_Users_TeacherId",
//                        column: x => x.TeacherId,
//                        principalTable: "Users",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "UserAnswerDetails",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    UserAnswerId = table.Column<int>(type: "int", nullable: false),
//                    OptionBankId = table.Column<int>(type: "int", nullable: false),
//                    QuestionBankId = table.Column<int>(type: "int", nullable: false),
//                    QuestionScores = table.Column<int>(type: "int", nullable: false),
//                    OptionScores = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_UserAnswerDetails", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_UserAnswerDetails_OptionBanks_OptionBankId",
//                        column: x => x.OptionBankId,
//                        principalTable: "OptionBanks",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_UserAnswerDetails_QuestionBanks_QuestionBankId",
//                        column: x => x.QuestionBankId,
//                        principalTable: "QuestionBanks",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_UserAnswerDetails_UserAnswers_UserAnswerId",
//                        column: x => x.UserAnswerId,
//                        principalTable: "UserAnswers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_BankSubjects_QuestionBankId",
//                table: "BankSubjects",
//                column: "QuestionBankId");

//            migrationBuilder.CreateIndex(
//                name: "IX_BankSubjects_SubjectId",
//                table: "BankSubjects",
//                column: "SubjectId");

//            migrationBuilder.CreateIndex(
//                name: "IX_MenuRole_RolesId",
//                table: "MenuRole",
//                column: "RolesId");

//            migrationBuilder.CreateIndex(
//                name: "IX_OptionBanks_QuestionBankId",
//                table: "OptionBanks",
//                column: "QuestionBankId");

//            migrationBuilder.CreateIndex(
//                name: "IX_QuestionBanks_QuestionTypeId",
//                table: "QuestionBanks",
//                column: "QuestionTypeId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Roles_QuestionBankId",
//                table: "Roles",
//                column: "QuestionBankId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Subjects_UserClassId",
//                table: "Subjects",
//                column: "UserClassId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserAnswerDetails_OptionBankId",
//                table: "UserAnswerDetails",
//                column: "OptionBankId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserAnswerDetails_QuestionBankId",
//                table: "UserAnswerDetails",
//                column: "QuestionBankId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserAnswerDetails_UserAnswerId",
//                table: "UserAnswerDetails",
//                column: "UserAnswerId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserAnswers_ClassId",
//                table: "UserAnswers",
//                column: "ClassId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserAnswers_SubjectId",
//                table: "UserAnswers",
//                column: "SubjectId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserAnswers_TeacherId",
//                table: "UserAnswers",
//                column: "TeacherId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserClasses_ClassesId",
//                table: "UserClasses",
//                column: "ClassesId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserClasses_UserId",
//                table: "UserClasses",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Users_ClassId",
//                table: "Users",
//                column: "ClassId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Users_RoleId",
//                table: "Users",
//                column: "RoleId");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "BankSubjects");

//            migrationBuilder.DropTable(
//                name: "MenuRole");

//            migrationBuilder.DropTable(
//                name: "UserAnswerDetails");

//            migrationBuilder.DropTable(
//                name: "Menus");

//            migrationBuilder.DropTable(
//                name: "OptionBanks");

//            migrationBuilder.DropTable(
//                name: "UserAnswers");

//            migrationBuilder.DropTable(
//                name: "Subjects");

//            migrationBuilder.DropTable(
//                name: "UserClasses");

//            migrationBuilder.DropTable(
//                name: "Users");

//            migrationBuilder.DropTable(
//                name: "Classes");

//            migrationBuilder.DropTable(
//                name: "Roles");

//            migrationBuilder.DropTable(
//                name: "QuestionBanks");

//            migrationBuilder.DropTable(
//                name: "QuestionType");
//        }
//    }
//}
