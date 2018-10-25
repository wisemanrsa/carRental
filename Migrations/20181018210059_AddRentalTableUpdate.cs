using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddRentalTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientNumber = table.Column<long>(nullable: false),
                    carRegistrationCode = table.Column<string>(nullable: true),
                    CarRegistrationNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    PickLoc = table.Column<string>(nullable: true),
                    ReturnLoc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_Car_CarRegistrationNumber",
                        column: x => x.CarRegistrationNumber,
                        principalTable: "Car",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rental_Client_ClientNumber",
                        column: x => x.ClientNumber,
                        principalTable: "Client",
                        principalColumn: "ClientNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarRegistrationNumber",
                table: "Rental",
                column: "CarRegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_ClientNumber",
                table: "Rental",
                column: "ClientNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");
        }
    }
}
