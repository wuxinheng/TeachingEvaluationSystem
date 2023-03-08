using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030803 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_OptionBanks_OptionBankId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_QuestionBanks_QuestionBankId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Users_UserId",
                table: "UserAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.RenameTable(
                name: "UserAnswers",
                newName: "UserAnswerDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswerDetails",
                newName: "IX_UserAnswerDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuestionBankId",
                table: "UserAnswerDetails",
                newName: "IX_UserAnswerDetails_QuestionBankId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_OptionBankId",
                table: "UserAnswerDetails",
                newName: "IX_UserAnswerDetails_OptionBankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswerDetails",
                table: "UserAnswerDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerDetails_OptionBanks_OptionBankId",
                table: "UserAnswerDetails",
                column: "OptionBankId",
                principalTable: "OptionBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerDetails_QuestionBanks_QuestionBankId",
                table: "UserAnswerDetails",
                column: "QuestionBankId",
                principalTable: "QuestionBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerDetails_Users_UserId",
                table: "UserAnswerDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerDetails_OptionBanks_OptionBankId",
                table: "UserAnswerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerDetails_QuestionBanks_QuestionBankId",
                table: "UserAnswerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerDetails_Users_UserId",
                table: "UserAnswerDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswerDetails",
                table: "UserAnswerDetails");

            migrationBuilder.RenameTable(
                name: "UserAnswerDetails",
                newName: "UserAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswerDetails_UserId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswerDetails_QuestionBankId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_QuestionBankId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswerDetails_OptionBankId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_OptionBankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_OptionBanks_OptionBankId",
                table: "UserAnswers",
                column: "OptionBankId",
                principalTable: "OptionBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_QuestionBanks_QuestionBankId",
                table: "UserAnswers",
                column: "QuestionBankId",
                principalTable: "QuestionBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Users_UserId",
                table: "UserAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
