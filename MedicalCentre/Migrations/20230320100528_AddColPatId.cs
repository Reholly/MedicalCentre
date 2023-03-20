using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class AddColPatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Patients_PatientId",
                table: "Notes");

            migrationBuilder.AlterColumn<uint>(
                name: "PatientId",
                table: "Notes",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u,
                oldClrType: typeof(uint),
                oldType: "int unsigned",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Patients_PatientId",
                table: "Notes",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Patients_PatientId",
                table: "Notes");

            migrationBuilder.AlterColumn<uint>(
                name: "PatientId",
                table: "Notes",
                type: "int unsigned",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "int unsigned");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Patients_PatientId",
                table: "Notes",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
