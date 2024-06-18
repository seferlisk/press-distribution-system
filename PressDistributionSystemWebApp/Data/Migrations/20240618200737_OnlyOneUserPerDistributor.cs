using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressDistributionSystemWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class OnlyOneUserPerDistributor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Distributors_DistributorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DistributorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Distributors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_UserId",
                table: "Distributors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_AspNetUsers_UserId",
                table: "Distributors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_AspNetUsers_UserId",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_UserId",
                table: "Distributors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Distributors");

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DistributorId",
                table: "AspNetUsers",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Distributors_DistributorId",
                table: "AspNetUsers",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id");
        }
    }
}
