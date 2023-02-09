using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCentre.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LogText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patiens",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patiens", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "specializations",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salary = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicalExaminations",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Conclusion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientId = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_patiens_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patiens",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoteText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublicationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PatientId = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notes_patiens_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patiens",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<uint>(type: "int unsigned", nullable: false),
                    SpecializationId = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageBytes = table.Column<byte[]>(type: "longblob", nullable: false),
                    MedicalExaminationId = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_employees_RoleId",
                table: "employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_SpecializationId",
                table: "employees",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_MedicalExaminationId",
                table: "Image",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_PatientId",
                table: "medicalExaminations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_notes_PatientId",
                table: "notes",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "specializations");

            migrationBuilder.DropTable(
                name: "medicalExaminations");

            migrationBuilder.DropTable(
                name: "patiens");
        }
    }
}
