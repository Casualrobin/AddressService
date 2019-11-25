﻿// <auto-generated />
using AddressService.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressService.Migrations
{
    [DbContext(typeof(AddressContext))]
    partial class AddressContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressService.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AggregateCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AggregateCity = "london",
                            City = "London",
                            Country = "England",
                            FirstName = "John",
                            LastName = "Smith",
                            StreetAddress = "Test St 1"
                        },
                        new
                        {
                            ID = 2,
                            AggregateCity = "london",
                            City = "London",
                            Country = "England",
                            FirstName = "Jane",
                            LastName = "Doe",
                            StreetAddress = "Test St 2"
                        },
                        new
                        {
                            ID = 3,
                            AggregateCity = "newyork",
                            City = "New York",
                            Country = "USA",
                            FirstName = "Tim",
                            LastName = "Jones",
                            StreetAddress = "Test St 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
