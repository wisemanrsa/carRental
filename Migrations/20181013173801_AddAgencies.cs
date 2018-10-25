using System.Collections.Generic;
using carRental.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddAgencies : Migration
    {
        private List<RentalAgency> Agancies()
        {
            var cars = new List<RentalAgency>();

            //AVIS
            cars.Add(new RentalAgency {Code = "AV1", Name = "AVIS", Street = "6 Plein Street, Johannesburg, 2001", City = "Johannesburg", Phone= "0117552500"});
            cars.Add(new RentalAgency {Code = "AV2", Name = "AVIS", Street = "89 Alberton Street, Witbank, 1035", City = "Witbank", Phone= "0117552501"});
            cars.Add(new RentalAgency {Code = "AV3", Name = "AVIS", Street = "16 Lou Street, Cape Town, 1436", City = "Cape Town", Phone= "0117552502"});
            cars.Add(new RentalAgency {Code = "AV4", Name = "AVIS", Street = "7 Kenny Street, Durban, 7412", City = "Durban", Phone= "0117552503"});
            cars.Add(new RentalAgency {Code = "AV5", Name = "AVIS", Street = "10 Mandela Street, Pretoria, 0001", City = "Pretoria", Phone= "0117552504"});

            //First Car
            cars.Add(new RentalAgency {Code = "FC1", Name = "First Car", Street = "10 Koke Street, Pretoria, 0001", City = "Pretoria", Phone= "0117552514"});
            cars.Add(new RentalAgency {Code = "FC2", Name = "First Car", Street = "96 Bree Street, Johannesburg, 2001", City = "Johannesburg", Phone= "0117552524"});
            cars.Add(new RentalAgency {Code = "FC3", Name = "First Car", Street = "1 Lolo Street, Witbank, 1035", City = "Witbank", Phone= "0117552534"});
            cars.Add(new RentalAgency {Code = "FC4", Name = "First Car", Street = "1 Keeny Street, Durban, 1035", City = "Durban", Phone= "0197552534"});
            cars.Add(new RentalAgency {Code = "FC5", Name = "First Car", Street = "1 Bololo Street, Cape Town, 1035", City = "Cape Town", Phone= "0118552534"});

            //Budget Rent
            cars.Add(new RentalAgency {Code = "BR1", Name = "Budget Rent", Street = "10 Koke Street, Pretoria, 0001", City = "Pretoria", Phone= "0117552514"});
            cars.Add(new RentalAgency {Code = "BR2", Name = "Budget Rent", Street = "96 Bree Street, Johannesburg, 2001", City = "Johannesburg", Phone= "0117552524"});
            cars.Add(new RentalAgency {Code = "BR3", Name = "Budget Rent", Street = "10 Derby Street, Witbank, 1035", City = "Witbank", Phone= "0117552534"});
            cars.Add(new RentalAgency {Code = "BR4", Name = "Budget Rent", Street = "18 FNB Street, Durban, 1230", City = "Durban", Phone= "0117552534"});
            cars.Add(new RentalAgency {Code = "BR5", Name = "Budget Rent", Street = "52 Cech Street, Cape Twon, 1035", City = "Cape Town", Phone= "0117552534"});

            return cars;
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var agencies = Agancies();

            foreach (var a in agencies)
            {
                migrationBuilder.Sql($"INSERT INTO RentalAgency(Code, Name, Street, City, Phone) VALUES('{a.Code}', '{a.Name}', '{a.Street}', '{a.City}', '{a.Phone}')");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var agencies = Agancies();
            foreach(var a in agencies)
            {
                migrationBuilder.Sql($"DELETE FROM RentalAgency WHERE Code = '{a.Code}'");
            }
        }
    }
}
