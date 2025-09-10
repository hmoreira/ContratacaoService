using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratacaoService.Adapters.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarConstrutorPadrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadosCliente_ClienteId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "DadosCliente_Nome",
                table: "Contratos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DadosCliente_ClienteId",
                table: "Contratos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DadosCliente_Nome",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
