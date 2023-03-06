using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030605 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBanks_Subject_SubjectId",
                table: "QuestionBanks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionBanks_SubjectId",
                table: "QuestionBanks");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "QuestionBanks");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionBankSubject");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "QuestionBanks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBanks_SubjectId",
                table: "QuestionBanks",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionBanks_Subject_SubjectId",
                table: "QuestionBanks",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");
        }
    }
}
