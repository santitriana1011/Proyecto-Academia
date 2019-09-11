﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myFirstAzureWebApp.Data;

namespace myFirstAzureWebApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190911174849_cmm")]
    partial class cmm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Acudiente", b =>
                {
                    b.Property<int>("AcudienteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Documento");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefono");

                    b.HasKey("AcudienteID");

                    b.ToTable("Acudiente");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Cargo", b =>
                {
                    b.Property<int>("CargoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CargoID");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<int>("CargoID");

                    b.Property<string>("Contrasenia");

                    b.Property<string>("Direccion");

                    b.Property<string>("Documento");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Rol")
                        .HasMaxLength(256);

                    b.Property<string>("Telefono");

                    b.HasKey("EmpleadoID");

                    b.HasIndex("CargoID");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Encuentros", b =>
                {
                    b.Property<int>("EncuentrosID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.Property<string>("Descripcion");

                    b.Property<int>("EscuelaID");

                    b.Property<string>("NombreEvento");

                    b.HasKey("EncuentrosID");

                    b.HasIndex("EscuelaID");

                    b.ToTable("Encuentros");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Escuela", b =>
                {
                    b.Property<int>("EscuelaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefono");

                    b.HasKey("EscuelaID");

                    b.ToTable("Escuela");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Estudiante", b =>
                {
                    b.Property<int>("EstudianteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcudienteID");

                    b.Property<string>("Apellido");

                    b.Property<string>("Documento");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhotoPath");

                    b.HasKey("EstudianteID");

                    b.HasIndex("AcudienteID");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.HojaDeVida", b =>
                {
                    b.Property<int>("HojaDeVidaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoID");

                    b.Property<string>("Especialidad");

                    b.Property<string>("TiempoExperiencia");

                    b.HasKey("HojaDeVidaID");

                    b.HasIndex("EmpleadoID");

                    b.ToTable("HojaDeVida");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Horario", b =>
                {
                    b.Property<int>("HorarioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoID");

                    b.Property<DateTime>("FechaHora");

                    b.HasKey("HorarioID");

                    b.HasIndex("EmpleadoID");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Tipo");

                    b.HasKey("ItemID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Mensualidad", b =>
                {
                    b.Property<int>("MensualidadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcudienteID");

                    b.Property<string>("Anio");

                    b.Property<DateTime>("FechaPago");

                    b.Property<string>("Mes");

                    b.Property<int>("Valor");

                    b.HasKey("MensualidadID");

                    b.HasIndex("AcudienteID");

                    b.ToTable("Mensualidad");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Nomina", b =>
                {
                    b.Property<int>("NominaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoID");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<int>("ItemID");

                    b.Property<int>("Valor");

                    b.HasKey("NominaID");

                    b.HasIndex("EmpleadoID");

                    b.HasIndex("ItemID");

                    b.ToTable("Nomina");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.NovedadMedica", b =>
                {
                    b.Property<int>("NovedadMedicaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(256);

                    b.Property<int>("EmpleadoID");

                    b.Property<int>("EstudianteID");

                    b.Property<DateTime>("FechaLesion");

                    b.HasKey("NovedadMedicaID");

                    b.HasIndex("EmpleadoID");

                    b.HasIndex("EstudianteID");

                    b.ToTable("NovedadMedica");
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Traspaso", b =>
                {
                    b.Property<int>("TraspasoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EscuelaID");

                    b.Property<int>("EstudianteID");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<string>("Novedades")
                        .HasMaxLength(256);

                    b.HasKey("TraspasoID");

                    b.HasIndex("EscuelaID");

                    b.HasIndex("EstudianteID");

                    b.ToTable("Traspaso");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Empleado", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Encuentros", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Escuela", "Escuela")
                        .WithMany()
                        .HasForeignKey("EscuelaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Estudiante", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Acudiente", "Acudiente")
                        .WithMany()
                        .HasForeignKey("AcudienteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.HojaDeVida", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Horario", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Mensualidad", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Acudiente", "Acudiente")
                        .WithMany()
                        .HasForeignKey("AcudienteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Nomina", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("myFirstAzureWebApp.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.NovedadMedica", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("myFirstAzureWebApp.Models.Estudiante", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myFirstAzureWebApp.Models.Traspaso", b =>
                {
                    b.HasOne("myFirstAzureWebApp.Models.Escuela", "Escuela")
                        .WithMany()
                        .HasForeignKey("EscuelaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("myFirstAzureWebApp.Models.Estudiante", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
