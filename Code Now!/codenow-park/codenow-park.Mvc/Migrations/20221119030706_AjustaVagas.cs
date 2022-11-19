using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codenowpark.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AjustaVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaga_Estacionamentos_EstacionamentoId",
                table: "Vaga");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaga_Veiculos_VeiculoId",
                table: "Vaga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaga",
                table: "Vaga");

            migrationBuilder.RenameTable(
                name: "Vaga",
                newName: "Vagas");

            migrationBuilder.RenameIndex(
                name: "IX_Vaga_VeiculoId",
                table: "Vagas",
                newName: "IX_Vagas_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaga_EstacionamentoId",
                table: "Vagas",
                newName: "IX_Vagas_EstacionamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas",
                column: "EstacionamentoId",
                principalTable: "Estacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Veiculos_VeiculoId",
                table: "Vagas",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Veiculos_VeiculoId",
                table: "Vagas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas");

            migrationBuilder.RenameTable(
                name: "Vagas",
                newName: "Vaga");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_VeiculoId",
                table: "Vaga",
                newName: "IX_Vaga_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_EstacionamentoId",
                table: "Vaga",
                newName: "IX_Vaga_EstacionamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaga",
                table: "Vaga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaga_Estacionamentos_EstacionamentoId",
                table: "Vaga",
                column: "EstacionamentoId",
                principalTable: "Estacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaga_Veiculos_VeiculoId",
                table: "Vaga",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
