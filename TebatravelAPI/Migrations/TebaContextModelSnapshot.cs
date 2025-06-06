﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TebatravelAPI.Context;

#nullable disable

namespace TebatravelAPI.Migrations
{
    [DbContext(typeof(TebaContext))]
    partial class TebaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TebatravelAPI.Entities.AlumnoEntity", b =>
                {
                    b.Property<int>("AlummnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlummnoId"));

                    b.Property<int>("CarreraId")
                        .HasColumnType("integer");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EscuelaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Materno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumCelular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Paterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AlummnoId")
                        .HasName("PK_AlumnoId");

                    b.HasIndex("CarreraId")
                        .IsUnique();

                    b.HasIndex("EscuelaId")
                        .IsUnique();

                    b.ToTable("Alumno", (string)null);
                });

            modelBuilder.Entity("TebatravelAPI.Entities.AsistenciaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FechaAsistencia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdAlumno")
                        .HasColumnType("integer");

                    b.Property<int>("IdCarrera")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_AsistenciaId");

                    b.ToTable("Asistencia", (string)null);
                });

            modelBuilder.Entity("TebatravelAPI.Entities.CarreraEntity", b =>
                {
                    b.Property<int>("CarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarreraId"));

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarreraId")
                        .HasName("PK_CarreraId");

                    b.ToTable("Carrera", (string)null);
                });

            modelBuilder.Entity("TebatravelAPI.Entities.EscuelaEntity", b =>
                {
                    b.Property<int>("EscuelaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EscuelaId"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreEscuela")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EscuelaId")
                        .HasName("PK_EscuelaId");

                    b.ToTable("Escuela", (string)null);
                });

            modelBuilder.Entity("TebatravelAPI.Entities.AlumnoEntity", b =>
                {
                    b.HasOne("TebatravelAPI.Entities.CarreraEntity", "Carrera")
                        .WithOne("Alumno")
                        .HasForeignKey("TebatravelAPI.Entities.AlumnoEntity", "CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TebatravelAPI.Entities.EscuelaEntity", "Escuela")
                        .WithOne("Alumno")
                        .HasForeignKey("TebatravelAPI.Entities.AlumnoEntity", "EscuelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("Escuela");
                });

            modelBuilder.Entity("TebatravelAPI.Entities.CarreraEntity", b =>
                {
                    b.Navigation("Alumno")
                        .IsRequired();
                });

            modelBuilder.Entity("TebatravelAPI.Entities.EscuelaEntity", b =>
                {
                    b.Navigation("Alumno")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
