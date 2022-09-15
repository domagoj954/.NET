using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations
{
    public partial class PovezaniModeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CeoId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CeoId",
                table: "Employees",
                column: "CeoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Ceos_CeoId",
                table: "Employees",
                column: "CeoId",
                principalTable: "Ceos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Ceos_CeoId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CeoId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CeoId",
                table: "Employees");
        }
    }
}
