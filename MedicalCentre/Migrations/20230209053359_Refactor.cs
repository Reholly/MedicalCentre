using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MedicalExaminations_MedicalExaminationId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminations_Patients_PatientId",
                table: "MedicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_Images_MedicalExaminationId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MedicalExaminationId",
                table: "Images");

            migrationBuilder.AlterColumn<uint>(
                name: "PatientId",
                table: "MedicalExaminations",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u,
                oldClrType: typeof(uint),
                oldType: "int unsigned",
                oldNullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "AttachedImageId",
                table: "MedicalExaminations",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_AttachedImageId",
                table: "MedicalExaminations",
                column: "AttachedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminations_Images_AttachedImageId",
                table: "MedicalExaminations",
                column: "AttachedImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminations_Patients_PatientId",
                table: "MedicalExaminations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminations_Images_AttachedImageId",
                table: "MedicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminations_Patients_PatientId",
                table: "MedicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_MedicalExaminations_AttachedImageId",
                table: "MedicalExaminations");

            migrationBuilder.DropColumn(
                name: "AttachedImageId",
                table: "MedicalExaminations");

            migrationBuilder.AlterColumn<uint>(
                name: "PatientId",
                table: "MedicalExaminations",
                type: "int unsigned",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "int unsigned");

            migrationBuilder.AddColumn<uint>(
                name: "MedicalExaminationId",
                table: "Images",
                type: "int unsigned",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MedicalExaminationId",
                table: "Images",
                column: "MedicalExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MedicalExaminations_MedicalExaminationId",
                table: "Images",
                column: "MedicalExaminationId",
                principalTable: "MedicalExaminations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminations_Patients_PatientId",
                table: "MedicalExaminations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
