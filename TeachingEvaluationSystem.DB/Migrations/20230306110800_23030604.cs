using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030604 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionBankRole");

            migrationBuilder.AddColumn<int>(
                name: "QuestionBankId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "QuestionBanks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_QuestionBankId",
                table: "Roles",
                column: "QuestionBankId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_QuestionBanks_QuestionBankId",
                table: "Roles",
                column: "QuestionBankId",
                principalTable: "QuestionBanks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBanks_Subject_SubjectId",
                table: "QuestionBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_QuestionBanks_QuestionBankId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_QuestionBankId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_QuestionBanks_SubjectId",
                table: "QuestionBanks");

            migrationBuilder.DropColumn(
                name: "QuestionBankId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "QuestionBanks");

            migrationBuilder.CreateTable(
                name: "QuestionBankRole",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBankRole", x => new { x.QuestionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_QuestionBankRole_QuestionBanks_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "QuestionBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionBankRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBankRole_RolesId",
                table: "QuestionBankRole",
                column: "RolesId");
        }
    }
}
