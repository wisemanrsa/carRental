﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using carRental.Models;

namespace ngxadminstarterkit.Migrations
{
    [DbContext(typeof(RentalDbContext))]
    [Migration("20180928212434_AddColors")]
    partial class AddColors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("carRental.Models.Car", b =>
                {
                    b.Property<string>("RegistrationNumber");

                    b.Property<string>("ColorCode");

                    b.Property<DateTime>("LastServiceDate");

                    b.Property<string>("RentalAgencyCode");

                    b.HasKey("RegistrationNumber");

                    b.HasIndex("ColorCode");

                    b.HasIndex("RentalAgencyCode");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("carRental.Models.CarType", b =>
                {
                    b.Property<string>("Code");

                    b.Property<bool>("Automatic");

                    b.Property<int>("CarSizeId");

                    b.Property<bool>("Conditioner");

                    b.Property<double>("EngineSize");

                    b.Property<string>("FuelType");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("SizeCode")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<double>("Tarrif");

                    b.HasKey("Code");

                    b.HasIndex("SizeCode");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("carRental.Models.Client", b =>
                {
                    b.Property<long>("ClientNumber");

                    b.Property<string>("City");

                    b.Property<long>("IdNumber")
                        .HasMaxLength(13);

                    b.Property<string>("Initials");

                    b.Property<string>("Phone");

                    b.Property<string>("Sex");

                    b.Property<string>("Street");

                    b.Property<string>("Surname");

                    b.HasKey("ClientNumber");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("carRental.Models.Color", b =>
                {
                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Code");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("carRental.Models.Employee", b =>
                {
                    b.Property<long>("StaffNumber");

                    b.Property<DateTime>("DateOfAppointment");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<long>("IdNumber")
                        .HasMaxLength(13);

                    b.Property<string>("Initials");

                    b.Property<string>("JobCode");

                    b.Property<long>("Number")
                        .HasMaxLength(10);

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("StaffNumber");

                    b.HasIndex("JobCode");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("carRental.Models.Job", b =>
                {
                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Code");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("carRental.Models.RentalAgency", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3);

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Street");

                    b.HasKey("Code");

                    b.ToTable("RentalAgency");
                });

            modelBuilder.Entity("carRental.Models.Size", b =>
                {
                    b.Property<string>("Code")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("Description");

                    b.HasKey("Code");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("carRental.Models.Car", b =>
                {
                    b.HasOne("carRental.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorCode");

                    b.HasOne("carRental.Models.RentalAgency", "RentalAgency")
                        .WithMany()
                        .HasForeignKey("RentalAgencyCode");
                });

            modelBuilder.Entity("carRental.Models.CarType", b =>
                {
                    b.HasOne("carRental.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeCode");
                });

            modelBuilder.Entity("carRental.Models.Employee", b =>
                {
                    b.HasOne("carRental.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobCode");
                });
#pragma warning restore 612, 618
        }
    }
}
