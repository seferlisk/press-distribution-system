using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressDistributionSystemWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReturnedQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReturnedQuantity",
                table: "KioskPublications",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnedQuantity",
                table: "KioskPublications");
        }
    }
}
