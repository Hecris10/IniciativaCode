using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codenowpark.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstacionamentoId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TempoEstacionado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ocupado = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaga_Estacionamentos_EstacionamentoId",
                        column: x => x.EstacionamentoId,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaga_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_EstacionamentoId",
                table: "Vaga",
                column: "EstacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_VeiculoId",
                table: "Vaga",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaga");
        }
    }
}
