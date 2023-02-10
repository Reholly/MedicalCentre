﻿// <auto-generated />
using System;
using MedicalCentre.DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalCentre.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230209160523_DeleteSpecializationTable")]
    partial class DeleteSpecializationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MedicalCentre.Models.Employee", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint>("RoleId")
                        .HasColumnType("int unsigned");

                    b.Property<double>("Salary")
                        .HasColumnType("double");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MedicalCentre.Models.Image", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<byte[]>("ImageBytes")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MedicalCentre.Models.Log", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("LogText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("MedicalCentre.Models.MedicalExamination", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint>("AttachedImageId")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Conclusion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint>("PatientId")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AttachedImageId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalExaminations");
                });

            modelBuilder.Entity("MedicalCentre.Models.Note", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("NoteText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint?>("PatientId")
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("MedicalCentre.Models.Patient", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalCentre.Roles.Role", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MedicalCentre.Models.Employee", b =>
                {
                    b.HasOne("MedicalCentre.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MedicalCentre.Models.MedicalExamination", b =>
                {
                    b.HasOne("MedicalCentre.Models.Image", "AttachedImage")
                        .WithMany()
                        .HasForeignKey("AttachedImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCentre.Models.Patient", null)
                        .WithMany("Examinations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttachedImage");
                });

            modelBuilder.Entity("MedicalCentre.Models.Note", b =>
                {
                    b.HasOne("MedicalCentre.Models.Patient", null)
                        .WithMany("Notes")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("MedicalCentre.Models.Patient", b =>
                {
                    b.Navigation("Examinations");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
