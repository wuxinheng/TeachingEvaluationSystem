using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030606 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "UserAnswers",
                newName: "QuestionScores");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "UserAnswers",
                newName: "QuestionBankId");

            migrationBuilder.AddColumn<int>(
                name: "OptionBankId",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptionScores",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrossScore",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_OptionBankId",
                table: "UserAnswers",
                column: "OptionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionBankId",
                table: "UserAnswers",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers",
                column: "UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_OptionBankId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuestionBankId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "OptionBankId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "OptionScores",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "GrossScore",
                table: "Subject");

            migrationBuilder.RenameColumn(
                name: "QuestionScores",
                table: "UserAnswers",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "QuestionBankId",
                table: "UserAnswers",
                newName: "OptionId");
        }
    }
}
