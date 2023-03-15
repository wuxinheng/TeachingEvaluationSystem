using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    /// <inheritdoc />
    public partial class _23031501 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "1233");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subjects",
                newSchema: "1233");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Subjects",
                schema: "1233",
                newName: "Subjects");
        }
    }
}
