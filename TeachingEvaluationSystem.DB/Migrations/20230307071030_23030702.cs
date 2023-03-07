using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030702 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionBankSubject");

            migrationBuilder.CreateTable(
                name: "BankSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    QuestionBankId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankSubjects_QuestionBanks_QuestionBankId",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankSubjects_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankSubjects_QuestionBankId",
                table: "BankSubjects",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankSubjects_SubjectId",
                table: "BankSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankSubjects");

            migrationBuilder.CreateTable(
                name: "QuestionBankSubject",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBankSubject", x => new { x.QuestionsId, x.QuestionsId1 });
                    table.ForeignKey(
                        name: "FK_QuestionBankSubject_QuestionBanks_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionBankSubject_Subject_QuestionsId1",
                        column: x => x.QuestionsId1,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBankSubject_QuestionsId1",
                table: "QuestionBankSubject",
                column: "QuestionsId1");
        }
    }
}
