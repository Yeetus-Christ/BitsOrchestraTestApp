﻿// <auto-generated />
using System;
using BitsOrchestraTestApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitsOrchestraTestApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240928133026_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BitsOrchestraTestApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Married")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Flory McLuckie",
                            Phone = "678-606-5234",
                            Salary = 5739m
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Angelo Iacobetto",
                            Phone = "718-384-4919",
                            Salary = 504m
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Eada Frome",
                            Phone = "747-226-5268",
                            Salary = 23585m
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Ibbie Glewe",
                            Phone = "505-161-4189",
                            Salary = 36789m
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Ashly Waldie",
                            Phone = "294-825-5871",
                            Salary = 944m
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Holden Ridgeway",
                            Phone = "219-790-4260",
                            Salary = 1m
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Arnuad Dimitriou",
                            Phone = "787-414-1823",
                            Salary = 10m
                        },
                        new
                        {
                            Id = 8,
                            DateOfBirth = new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Lorianne Sanney",
                            Phone = "536-923-6367",
                            Salary = 4327m
                        },
                        new
                        {
                            Id = 9,
                            DateOfBirth = new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Filmer Basindale",
                            Phone = "937-235-4935",
                            Salary = 17243m
                        },
                        new
                        {
                            Id = 10,
                            DateOfBirth = new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Rodolphe Cassie",
                            Phone = "962-414-2092",
                            Salary = 7m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
