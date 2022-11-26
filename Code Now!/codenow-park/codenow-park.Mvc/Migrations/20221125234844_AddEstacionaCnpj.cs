using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codenowpark.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddEstacionaCnpj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Estacionamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Estacionamentos");
        }
    }
}
