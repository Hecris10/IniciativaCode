using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codenowpark.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddPrecoVaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoEstacionado",
                table: "Vagas");

            migrationBuilder.AddColumn<double>(
                name: "HorasEstacionado",
                table: "Vagas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorPagar",
                table: "Vagas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorPago",
                table: "Vagas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "PrecoInicial",
                table: "Estacionamentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecoHora",
                table: "Estacionamentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasEstacionado",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "ValorPagar",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "ValorPago",
                table: "Vagas");

            migrationBuilder.AddColumn<DateTime>(
                name: "TempoEstacionado",
                table: "Vagas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoInicial",
                table: "Estacionamentos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoHora",
                table: "Estacionamentos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
