using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class AddTableImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_MedicalExaminations_MedicalExaminationId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Image_MedicalExaminationId",
                table: "Images",
                newName: "IX_Images_MedicalExaminationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MedicalExaminations_MedicalExaminationId",
                table: "Images",
                column: "MedicalExaminationId",
                principalTable: "MedicalExaminations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MedicalExaminations_MedicalExaminationId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Images_MedicalExaminationId",
                table: "Image",
                newName: "IX_Image_MedicalExaminationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_MedicalExaminations_MedicalExaminationId",
                table: "Image",
                column: "MedicalExaminationId",
                principalTable: "MedicalExaminations",
                principalColumn: "Id");
        }
    }
}
