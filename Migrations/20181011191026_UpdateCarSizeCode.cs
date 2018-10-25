using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class UpdateCarSizeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarSizeId",
                table: "CarType");

            migrationBuilder.AddColumn<string>(
                name: "CarSizeCode",
                table: "CarType",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarSizeCode",
                table: "CarType");

            migrationBuilder.AddColumn<int>(
                name: "CarSizeId",
                table: "CarType",
                nullable: false,
                defaultValue: 0);
        }
    }
}
