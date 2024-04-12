using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_de_Transporte.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instituicaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeInstituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manutencaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoManutencao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manutencaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "matriculaFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculaFuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "matriculaTransportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculaTransportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipoDeTransportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTransporte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoDeTransportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Instituicaos_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTransporteId = table.Column<int>(type: "int", nullable: false),
                    MatriculaFuncionarioId = table.Column<int>(type: "int", nullable: false),
                    MatriculaTransporteId = table.Column<int>(type: "int", nullable: false),
                    ManutencaoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDeTransporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transportes_manutencaos_ManutencaoId",
                        column: x => x.ManutencaoId,
                        principalTable: "manutencaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transportes_matriculaFuncionarios_MatriculaFuncionarioId",
                        column: x => x.MatriculaFuncionarioId,
                        principalTable: "matriculaFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transportes_matriculaTransportes_MatriculaTransporteId",
                        column: x => x.MatriculaTransporteId,
                        principalTable: "matriculaTransportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transportes_tipoDeTransportes_TipoDeTransporteId",
                        column: x => x.TipoDeTransporteId,
                        principalTable: "tipoDeTransportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    MatriculaFuncionarioId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    MatriculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_matriculaFuncionarios_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "matriculaFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    FuncionariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_InstituicaoId",
                table: "Departamentos",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoId",
                table: "Funcionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_MatriculaId",
                table: "Funcionarios",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_transportes_ManutencaoId",
                table: "transportes",
                column: "ManutencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_transportes_MatriculaFuncionarioId",
                table: "transportes",
                column: "MatriculaFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_transportes_MatriculaTransporteId",
                table: "transportes",
                column: "MatriculaTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_transportes_TipoDeTransporteId",
                table: "transportes",
                column: "TipoDeTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FuncionariosId",
                table: "Usuarios",
                column: "FuncionariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transportes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "manutencaos");

            migrationBuilder.DropTable(
                name: "matriculaTransportes");

            migrationBuilder.DropTable(
                name: "tipoDeTransportes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "matriculaFuncionarios");

            migrationBuilder.DropTable(
                name: "Instituicaos");
        }
    }
}
