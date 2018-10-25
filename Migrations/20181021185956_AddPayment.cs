using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PickUp",
                table: "PickUp");

            migrationBuilder.RenameTable(
                name: "PickUp",
                newName: "Pickup");

            migrationBuilder.RenameColumn(
                name: "carRegistrationCode",
                table: "Rental",
                newName: "CarRegistrationCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pickup",
                table: "Pickup",
                column: "ClientNumber");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientNumber = table.Column<long>(nullable: false),
                    amount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pickup",
                table: "Pickup");

            migrationBuilder.RenameTable(
                name: "Pickup",
                newName: "PickUp");

            migrationBuilder.RenameColumn(
                name: "CarRegistrationCode",
                table: "Rental",
                newName: "carRegistrationCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PickUp",
                table: "PickUp",
                column: "ClientNumber");
        }
    }
}
