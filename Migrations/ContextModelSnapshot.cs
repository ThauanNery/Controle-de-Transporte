﻿// <auto-generated />
using System;
using Controle_de_Transporte.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Controle_de_Transporte.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Controle_de_Transporte.Models.CargoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.DepartamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.FuncionariosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("MatriculaFuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("MatriculaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("MatriculaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.InstituicaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeInstituicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instituicaos");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.ManutencaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Custo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoManutencao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("manutencaos");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.MatriculaFuncionarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("matriculaFuncionarios");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.MatriculaTransporteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("matriculaTransportes");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.TipoDeTransporteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeTransporte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tipoDeTransportes");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.TransporteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManutencaoId")
                        .HasColumnType("int");

                    b.Property<int>("MatriculaFuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("MatriculaTransporteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeTransporteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoTransporteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManutencaoId");

                    b.HasIndex("MatriculaFuncionarioId");

                    b.HasIndex("MatriculaTransporteId");

                    b.HasIndex("TipoDeTransporteId");

                    b.ToTable("transportes");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionariosId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionariosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.DepartamentoModel", b =>
                {
                    b.HasOne("Controle_de_Transporte.Models.InstituicaoModel", "Instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.FuncionariosModel", b =>
                {
                    b.HasOne("Controle_de_Transporte.Models.CargoModel", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Transporte.Models.DepartamentoModel", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Transporte.Models.MatriculaFuncionarioModel", "Matricula")
                        .WithMany()
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Departamento");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.TransporteModel", b =>
                {
                    b.HasOne("Controle_de_Transporte.Models.ManutencaoModel", "Manutencao")
                        .WithMany()
                        .HasForeignKey("ManutencaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Transporte.Models.MatriculaFuncionarioModel", "MatriculaFuncionario")
                        .WithMany()
                        .HasForeignKey("MatriculaFuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Transporte.Models.MatriculaTransporteModel", "MatriculaTransporte")
                        .WithMany()
                        .HasForeignKey("MatriculaTransporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Transporte.Models.TipoDeTransporteModel", "TipoDeTransporte")
                        .WithMany()
                        .HasForeignKey("TipoDeTransporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manutencao");

                    b.Navigation("MatriculaFuncionario");

                    b.Navigation("MatriculaTransporte");

                    b.Navigation("TipoDeTransporte");
                });

            modelBuilder.Entity("Controle_de_Transporte.Models.UsuarioModel", b =>
                {
                    b.HasOne("Controle_de_Transporte.Models.FuncionariosModel", "Funcionarios")
                        .WithMany()
                        .HasForeignKey("FuncionariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
