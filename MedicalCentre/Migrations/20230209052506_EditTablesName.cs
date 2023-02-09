using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class EditTablesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_specializations_SpecializationId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_medicalExaminations_MedicalExaminationId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_patiens_PatientId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_patiens_PatientId",
                table: "notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specializations",
                table: "specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                table: "notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicalExaminations",
                table: "medicalExaminations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_logs",
                table: "logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patiens",
                table: "patiens");

            migrationBuilder.RenameTable(
                name: "specializations",
                newName: "Specializations");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "notes",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "medicalExaminations",
                newName: "MedicalExaminations");

            migrationBuilder.RenameTable(
                name: "logs",
                newName: "Logs");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "patiens",
                newName: "Patients");

            migrationBuilder.RenameIndex(
                name: "IX_notes_PatientId",
                table: "Notes",
                newName: "IX_Notes_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_medicalExaminations_PatientId",
                table: "MedicalExaminations",
                newName: "IX_MedicalExaminations_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_SpecializationId",
                table: "Employees",
                newName: "IX_Employees_SpecializationId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_RoleId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalExaminations",
                table: "MedicalExaminations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Specializations_SpecializationId",
                table: "Employees",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_MedicalExaminations_MedicalExaminationId",
                table: "Image",
                column: "MedicalExaminationId",
                principalTable: "MedicalExaminations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminations_Patients_PatientId",
                table: "MedicalExaminations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Patients_PatientId",
                table: "Notes",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Specializations_SpecializationId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_MedicalExaminations_MedicalExaminationId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminations_Patients_PatientId",
                table: "MedicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Patients_PatientId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalExaminations",
                table: "MedicalExaminations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Specializations",
                newName: "specializations");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "notes");

            migrationBuilder.RenameTable(
                name: "MedicalExaminations",
                newName: "medicalExaminations");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "logs");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "patiens");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_PatientId",
                table: "notes",
                newName: "IX_notes_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalExaminations_PatientId",
                table: "medicalExaminations",
                newName: "IX_medicalExaminations_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SpecializationId",
                table: "employees",
                newName: "IX_employees_SpecializationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "employees",
                newName: "IX_employees_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specializations",
                table: "specializations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                table: "notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicalExaminations",
                table: "medicalExaminations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logs",
                table: "logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patiens",
                table: "patiens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_specializations_SpecializationId",
                table: "employees",
                column: "SpecializationId",
                principalTable: "specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_medicalExaminations_MedicalExaminationId",
                table: "Image",
                column: "MedicalExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_patiens_PatientId",
                table: "medicalExaminations",
                column: "PatientId",
                principalTable: "patiens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_patiens_PatientId",
                table: "notes",
                column: "PatientId",
                principalTable: "patiens",
                principalColumn: "Id");
        }
    }
}
