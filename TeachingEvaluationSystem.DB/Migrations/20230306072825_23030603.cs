using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030603 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBanks_QuestionType_QuestionTypeId",
                table: "QuestionBanks");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTypeId",
                table: "QuestionBanks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_UserClasses_UserClassId",
                        column: x => x.UserClassId,
                        principalTable: "UserClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UserClassId",
                table: "Subject",
                column: "UserClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionBanks_QuestionType_QuestionTypeId",
                table: "QuestionBanks",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBanks_QuestionType_QuestionTypeId",
                table: "QuestionBanks");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTypeId",
                table: "QuestionBanks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionBanks_QuestionType_QuestionTypeId",
                table: "QuestionBanks",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id");
        }
    }
}
