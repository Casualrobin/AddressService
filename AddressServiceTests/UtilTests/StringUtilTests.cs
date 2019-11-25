using AddressService.Utils;
using NUnit.Framework;

namespace AddressServiceTests.UtilTests
{
    class StringUtilTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("SAn FraNSisco","sanfransisco")]
        [TestCase("  london", "london")]
        [TestCase("newcastle", "newcastle")]
        public void NormaliseUnusualCityName(string city, string normedcity)
        {
            Assert.AreEqual(StringUtils.NormaliseCityName(city), normedcity);
        }
        
        [TestCase("aunt", "ant", 1)]
        [TestCase("Sam", "Samantha", 5)]
        [TestCase("flomax", "volmax", 3)]
        [TestCase("kitten", "sitting", 3)]
        public void CalculateLevenshteinDistance(string s1, string s2, int expectedDistance)
        {
            var distance = StringUtils.LevenshteinDistance(s1, s2);
            Assert.AreEqual(expectedDistance, distance);
        }
    }
}
