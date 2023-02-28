using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class EditOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employees_EmployeeAccountId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_EmployeeAccountId",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployeeAccountId",
                table: "Accounts",
                column: "EmployeeAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employees_EmployeeAccountId",
                table: "Accounts",
                column: "EmployeeAccountId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
