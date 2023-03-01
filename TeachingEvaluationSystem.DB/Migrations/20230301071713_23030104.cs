using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachingEvaluationSystem.DB.Migrations
{
    public partial class _23030104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_MenuId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "MenuRole",
                columns: table => new
                {
                    MenusId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRole", x => new { x.MenusId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_MenuRole_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_RolesId",
                table: "MenuRole",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRole");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MenuId",
                table: "Roles",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
