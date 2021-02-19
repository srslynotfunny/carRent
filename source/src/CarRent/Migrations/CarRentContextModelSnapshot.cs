﻿// <auto-generated />
using System;
using CarRent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRent.Migrations
{
    [DbContext(typeof(CarRentContext))]
    partial class CarRentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("CarRent.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PricePerDay")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRent.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Postalcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRent.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Costs")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
