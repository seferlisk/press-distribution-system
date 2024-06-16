using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressDistributionSystemWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtraNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationDistributors_Distributors_DistributorId",
                table: "PublicationDistributors");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationDistributors_Publications_PublicationId",
                table: "PublicationDistributors");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "PublicationDistributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DistributorId",
                table: "PublicationDistributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationDistributors_Distributors_DistributorId",
                table: "PublicationDistributors",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationDistributors_Publications_PublicationId",
                table: "PublicationDistributors",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationDistributors_Distributors_DistributorId",
                table: "PublicationDistributors");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationDistributors_Publications_PublicationId",
                table: "PublicationDistributors");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "PublicationDistributors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistributorId",
                table: "PublicationDistributors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationDistributors_Distributors_DistributorId",
                table: "PublicationDistributors",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationDistributors_Publications_PublicationId",
                table: "PublicationDistributors",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
