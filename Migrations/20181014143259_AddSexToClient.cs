using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddSexToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Client");
        }
    }
}
