using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030804 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerDetails_Users_UserId",
                table: "UserAnswerDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserAnswerDetails",
                newName: "UserAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswerDetails_UserId",
                table: "UserAnswerDetails",
                newName: "IX_UserAnswerDetails_UserAnswerId");

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Scores = table.Column<int>(type: "int", nullable: false),
                    YearMonth = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_ClassId",
                table: "UserAnswers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_SubjectId",
                table: "UserAnswers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_TeacherId",
                table: "UserAnswers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerDetails_UserAnswers_UserAnswerId",
                table: "UserAnswerDetails",
                column: "UserAnswerId",
                principalTable: "UserAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerDetails_UserAnswers_UserAnswerId",
                table: "UserAnswerDetails");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "UserAnswerId",
                table: "UserAnswerDetails",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswerDetails_UserAnswerId",
                table: "UserAnswerDetails",
                newName: "IX_UserAnswerDetails_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerDetails_Users_UserId",
                table: "UserAnswerDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
