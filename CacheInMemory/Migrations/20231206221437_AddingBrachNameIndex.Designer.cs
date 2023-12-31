﻿// <auto-generated />
using CacheInMemory.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CacheInMemory.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231206221437_AddingBrachNameIndex")]
    partial class AddingBrachNameIndex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CacheInMemory.Model.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BranchId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("CacheInMemory.Model.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CacheInMemory.Model.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("CountryCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CacheInMemory.Model.RegisteredCar", b =>
                {
                    b.Property<int>("RegisteredCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RegisteredCarId");

                    b.ToTable("RegisteredCars");
                });
#pragma warning restore 612, 618
        }
    }
}
