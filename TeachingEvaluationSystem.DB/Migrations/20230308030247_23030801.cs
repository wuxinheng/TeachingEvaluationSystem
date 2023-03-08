using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23030801 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankSubjects_Subject_SubjectId",
                table: "BankSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_UserClasses_UserClassId",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_UserClassId",
                table: "Subjects",
                newName: "IX_Subjects_UserClassId");

            migrationBuilder.AlterColumn<int>(
                name: "UserClassId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankSubjects_Subjects_SubjectId",
                table: "BankSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_UserClasses_UserClassId",
                table: "Subjects",
                column: "UserClassId",
                principalTable: "UserClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankSubjects_Subjects_SubjectId",
                table: "BankSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_UserClasses_UserClassId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_UserClassId",
                table: "Subject",
                newName: "IX_Subject_UserClassId");

            migrationBuilder.AlterColumn<int>(
                name: "UserClassId",
                table: "Subject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankSubjects_Subject_SubjectId",
                table: "BankSubjects",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_UserClasses_UserClassId",
                table: "Subject",
                column: "UserClassId",
                principalTable: "UserClasses",
                principalColumn: "Id");
        }
    }
}
