using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressDistributionSystemWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuantityAndNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Publications");
        }
    }
}
