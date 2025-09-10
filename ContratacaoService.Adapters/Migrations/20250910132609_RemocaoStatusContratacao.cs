using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratacaoService.Adapters.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoStatusContratacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusContratacao",
                table: "Contratos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "StatusContratacao",
                table: "Contratos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
