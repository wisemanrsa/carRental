using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientNumber = table.Column<long>(nullable: false),
                    IdNumber = table.Column<long>(maxLength: 13, nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientNumber);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RentalAgency",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalAgency", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    StaffNumber = table.Column<long>(nullable: false),
                    IdNumber = table.Column<long>(maxLength: 13, nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Number = table.Column<long>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: true),
                    DateOfAppointment = table.Column<DateTime>(nullable: false),
                    JobCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.StaffNumber);
                    table.ForeignKey(
                        name: "FK_Employee_Job_JobCode",
                        column: x => x.JobCode,
                        principalTable: "Job",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    RegistrationNumber = table.Column<string>(nullable: false),
                    ColorCode = table.Column<string>(nullable: true),
                    LastServiceDate = table.Column<DateTime>(nullable: false),
                    RentalAgencyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.RegistrationNumber);
                    table.ForeignKey(
                        name: "FK_Car_Color_ColorCode",
                        column: x => x.ColorCode,
                        principalTable: "Color",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_RentalAgency_RentalAgencyCode",
                        column: x => x.RentalAgencyCode,
                        principalTable: "RentalAgency",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    EngineSize = table.Column<double>(nullable: false),
                    Tarrif = table.Column<double>(nullable: false),
                    Conditioner = table.Column<bool>(nullable: false),
                    Automatic = table.Column<bool>(nullable: false),
                    FuelType = table.Column<string>(nullable: true),
                    CarSizeId = table.Column<int>(nullable: false),
                    SizeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Code);
                    table.ForeignKey(
                        name: "FK_CarType_Size_SizeCode",
                        column: x => x.SizeCode,
                        principalTable: "Size",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ColorCode",
                table: "Car",
                column: "ColorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RentalAgencyCode",
                table: "Car",
                column: "RentalAgencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CarType_SizeCode",
                table: "CarType",
                column: "SizeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobCode",
                table: "Employee",
                column: "JobCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "RentalAgency");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
