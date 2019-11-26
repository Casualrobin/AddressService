using AddressService;
using AddressService.Controllers;
using AddressServiceTests.RepositoryTests;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;

namespace AddressServiceTests
{
    public class AddressControllerTests
    {
        TestRepository testRepo; 
        AddressController controller;
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
            testRepo = new TestRepository();
            controller = new AddressController(testRepo);
        }

        [Test]
        public void CorrectNumberOfResultsReturned()
        {
            testRepo.data.Add(a);
            testRepo.data.Add(b);
            testRepo.data.Add(c);

            var okObjectResult = controller.Get() as OkObjectResult;

            var model = (object[][]) okObjectResult.Value;

            Assert.NotNull(okObjectResult.Value);

            var actual = model.Length;

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void PostNewResultsAreRegistered()
        {
            List<Address> l = new List<Address>() { a,b,c };
            controller.PostMultipleAddresses(l);
            Assert.AreEqual(3, testRepo.data.Count);
        }

        [Test]
        public void DeleteByIdDeletsFromRepo()
        {
            testRepo.data.Add(a);
            testRepo.data.Add(b);
            testRepo.data.Add(c);
            Assert.AreEqual(3, testRepo.data.Count);

            controller.Delete(1);

            Assert.AreEqual(2, testRepo.data.Count);
        }

    }
}