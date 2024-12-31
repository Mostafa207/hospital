﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hospital.Data;

#nullable disable

namespace hospital.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    [Migration("20241231094058_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicinePatient", b =>
                {
                    b.Property<int>("medicinesId")
                        .HasColumnType("int");

                    b.Property<int>("pationsId")
                        .HasColumnType("int");

                    b.HasKey("medicinesId", "pationsId");

                    b.HasIndex("pationsId");

                    b.ToTable("MedicinePatient");
                });

            modelBuilder.Entity("hospital.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("doctorId")
                        .HasColumnType("int");

                    b.Property<int?>("patientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.HasIndex("patientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("hospital.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("hospital.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("hospital.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("hospital.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasFilter("[PatientId] IS NOT NULL");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("MedicinePatient", b =>
                {
                    b.HasOne("hospital.Models.Medicine", null)
                        .WithMany()
                        .HasForeignKey("medicinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hospital.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("pationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hospital.Models.Appointment", b =>
                {
                    b.HasOne("hospital.Models.Doctor", "doctor")
                        .WithMany("appointments")
                        .HasForeignKey("doctorId");

                    b.HasOne("hospital.Models.Patient", "patient")
                        .WithMany("appointments")
                        .HasForeignKey("patientId");

                    b.Navigation("doctor");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("hospital.Models.Prescription", b =>
                {
                    b.HasOne("hospital.Models.Patient", "Patient")
                        .WithOne("prescription")
                        .HasForeignKey("hospital.Models.Prescription", "PatientId");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("hospital.Models.Doctor", b =>
                {
                    b.Navigation("appointments");
                });

            modelBuilder.Entity("hospital.Models.Patient", b =>
                {
                    b.Navigation("appointments");

                    b.Navigation("prescription");
                });
#pragma warning restore 612, 618
        }
    }
}
