using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AlterCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Car",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CarTypeCode",
                table: "Car",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeCode",
                table: "Car",
                column: "CarTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarType_CarTypeCode",
                table: "Car",
                column: "CarTypeCode",
                principalTable: "CarType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarType_CarTypeCode",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_CarTypeCode",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CarTypeCode",
                table: "Car");
        }
    }
}
