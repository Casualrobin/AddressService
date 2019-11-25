using AddressService;
using AddressService.DBContexts;
using AddressService.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace AddressServiceTests.RepositoryTests
{
    class AddressRepositoryTests
    {
        Address a = new Address
        {
            ID = 1,
            FirstName = "John",
            LastName = "Smith",
            StreetAddress = "Test St 1",
            City = "London",
            Country = "England",
            AggregateCity = "london"
        };
        Address b = new Address
        {
            ID = 2,
            FirstName = "Jane",
            LastName = "Doe",
            StreetAddress = "Test St 2",
            City = "London",
            Country = "England",
            AggregateCity = "london"
        };
        Address c = new Address
        {
            ID = 3,
            FirstName = "Tim",
            LastName = "Jones",
            StreetAddress = "Test St 3",
            City = "New York",
            Country = "USA",
            AggregateCity = "newyork"
        };

        [SetUp]
        public void Setup()
        {
        }
        

        [Test]
        public void TestValidDeleteAddressById()
        {
            //Arrange

            var options = new DbContextOptionsBuilder<AddressContext>().UseInMemoryDatabase(databaseName: "Addresses").Options;
            var context = new AddressContext(options);
            context.Addresses.Add(a);
            context.SaveChanges();
            var repository = new AddressRepository(context);

            // Act
            repository.DeleteAddressById(1);

            //Assert
            Assert.AreEqual(0, context.Addresses.Count());

            context.Database.EnsureDeleted();
        }

        [Test]
        public void TestInvalidDeleteAddressById()
        {
            //Arrange

            var options = new DbContextOptionsBuilder<AddressContext>().UseInMemoryDatabase(databaseName: "Addresses").Options;
            var context = new AddressContext(options);
            context.Addresses.Add(a);
            var repository = new AddressRepository(context);

            // Assert
            Assert.Throws<ArgumentNullException>(() => repository.DeleteAddressById(2));

            context.Database.EnsureDeleted();
        }

        [Test]
        public void GetAddresses()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<AddressContext>().UseInMemoryDatabase(databaseName: "Addresses").Options;
            var context = new AddressContext(options);
            context.Addresses.AddRange(new Address[] { a, b, c });
            context.SaveChanges();
            var repository = new AddressRepository(context);

            // Act
            var output = repository.GetAddresses();

            //Assert
            Assert.AreEqual(3, output.Count());

            context.Database.EnsureDeleted();
        }

        [Test]
        public void InsertAddress()
        {
            //Arrange

            var options = new DbContextOptionsBuilder<AddressContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            var context = new AddressContext(options);

            var repository = new Mock<AddressRepository>(context);

            // Act
            repository.Object.InsertAddress(a);

            //Assert
            Assert.AreEqual(1, context.Addresses.Count());

            context.Database.EnsureDeleted();
        }
    }
}
