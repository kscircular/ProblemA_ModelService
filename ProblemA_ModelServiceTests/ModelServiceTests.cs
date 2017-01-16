using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemA_ModelService;
using System.Collections.Generic;

namespace ProblemA_ModelService.Tests
{
    [TestClass()]
    public class ModelServiceTests
    {
      

        [TestMethod()]
        public void GetCryptographicHashTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetIdenticalPropertiesTest()
        {
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA",Zip="98104" };
            List<string> properties=modelService.GetIdenticalProperties(address1, address1);
            Assert.AreEqual(5,properties.Count);
        }

        [TestMethod()]
        public void GetObjectDifferencesTest()
        {
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            Address address2 = new Address() { HouseNumber = "123", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            List<Difference> properties = modelService.GetObjectDifferences(address1, address2);
            Assert.AreEqual(1, properties.Count);
            Assert.AreEqual("123", properties[0].Value2);
        }
    }
}