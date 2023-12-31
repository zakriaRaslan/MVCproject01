﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMVC.Data;

#nullable disable

namespace WebMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230606110106_Add-Employees-table")]
    partial class AddEmployeestable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebMVC.Areas.Employees.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte?>("EmployeeAge")
                        .HasColumnType("tinyint");

                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeSalary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebMVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Select Category"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Mobiles"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Computers"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Electric Machines"
                        });
                });

            modelBuilder.Entity("WebMVC.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 6, 6, 14, 1, 6, 2, DateTimeKind.Local).AddTicks(2319),
                            Name = "Item1",
                            Price = 150m
                        });
                });

            modelBuilder.Entity("WebMVC.Models.Item", b =>
                {
                    b.HasOne("WebMVC.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebMVC.Models.Category", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
