using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSpecializationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Specializations_SpecializationId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SpecializationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Employees");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Employees",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Employees",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Employees");

            migrationBuilder.AddColumn<uint>(
                name: "SpecializationId",
                table: "Employees",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Salary = table.Column<uint>(type: "int unsigned", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SpecializationId",
                table: "Employees",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Specializations_SpecializationId",
                table: "Employees",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
