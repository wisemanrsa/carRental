using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddColors : Migration
    {
        private Dictionary<string, string> GetColors()
        {
            var colors = new Dictionary<string, string>();
            colors.Add("WH", "White");
            colors.Add("BK", "Black");
            colors.Add("YL", "Yellow");
            colors.Add("GN", "Green");
            colors.Add("RD", "Red");
            colors.Add("BL", "Blue");
            colors.Add("SL", "Silver");
            colors.Add("GY", "Grey");
            colors.Add("PT", "Pitch");
            colors.Add("VT", "Violet");
            colors.Add("ON", "Orange");

            return colors;
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var colors = GetColors();

            foreach(var color in colors)
                migrationBuilder.Sql($"INSERT INTO Color(Code, Description) VALUES ('{color.Key}', '{color.Value}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var colors = GetColors();

            foreach(var color in colors)
                migrationBuilder.Sql($"DELETE FROM Color WHERE Code = '{color.Key}'");
        }
    }
}
