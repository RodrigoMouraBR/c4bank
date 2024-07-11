using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustescampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "FinancialTransaction",
                newName: "DateRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRef",
                table: "FinancialTransaction",
                newName: "Date");
        }
    }
}
