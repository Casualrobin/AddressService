using AddressService;
using NUnit.Framework;

namespace AddressServiceTests.UtilTests
{
    class AddressUtilTests
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

        [Test]
        public void TestGetAggregateCityWhenInList()
        {
            var actual = AddressUtils.GetAggregateCity(a, new string[] { "london", "newyork" });

            Assert.AreEqual("london", actual);
        }

        [Test]
        public void TestGetAggregateCityWhenNotInList()
        {
            var actual = AddressUtils.GetAggregateCity(a, new string[] { "cat", "miami" });

            Assert.AreEqual("london", actual);
        }
    }
}
