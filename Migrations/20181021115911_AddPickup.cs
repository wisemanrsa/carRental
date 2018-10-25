using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddPickup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PickUp",
                columns: table => new
                {
                    ClientNumber = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUp", x => x.ClientNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickUp");
        }
    }
}
