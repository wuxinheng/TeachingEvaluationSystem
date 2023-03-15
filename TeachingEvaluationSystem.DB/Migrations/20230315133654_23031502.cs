using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23031502 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Subjects",
                schema: "1233",
                newName: "Subjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "1233");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subjects",
                newSchema: "1233");
        }
    }
}
