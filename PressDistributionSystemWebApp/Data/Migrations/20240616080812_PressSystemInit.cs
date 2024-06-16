using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressDistributionSystemWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PressSystemInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReturnDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kiosks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiosks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kiosks_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicationDistributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    PublicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationDistributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationDistributors_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationDistributors_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KioskPublications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    KioskId = table.Column<int>(type: "int", nullable: true),
                    PublicationDistributorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KioskPublications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KioskPublications_Kiosks_KioskId",
                        column: x => x.KioskId,
                        principalTable: "Kiosks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KioskPublications_PublicationDistributors_PublicationDistributorId",
                        column: x => x.PublicationDistributorId,
                        principalTable: "PublicationDistributors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DistributorId",
                table: "AspNetUsers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_KioskPublications_KioskId",
                table: "KioskPublications",
                column: "KioskId");

            migrationBuilder.CreateIndex(
                name: "IX_KioskPublications_PublicationDistributorId",
                table: "KioskPublications",
                column: "PublicationDistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Kiosks_DistributorId",
                table: "Kiosks",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationDistributors_DistributorId",
                table: "PublicationDistributors",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationDistributors_PublicationId",
                table: "PublicationDistributors",
                column: "PublicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Distributors_DistributorId",
                table: "AspNetUsers",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Distributors_DistributorId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "KioskPublications");

            migrationBuilder.DropTable(
                name: "Kiosks");

            migrationBuilder.DropTable(
                name: "PublicationDistributors");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DistributorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "AspNetUsers");
        }
    }
}
