using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemA_ModelService;
using System.Collections.Generic;

namespace ProblemA_ModelService.Tests
{
    [TestClass()]
    public class ModelServiceTests
    { 
        [TestMethod()]
        public void GetCryptographicHashTest_MD5CryptoServiceProvider()
        {
            string expected = "A065vD4zfPUNSaaUcuUHMQ==";
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            var result=modelService.GetCryptographicHash(address1, HashHelper.HashType.MD5CryptoServiceProvider);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetCryptographicHashTest_RIPEMD160Managed()
        {
            string expected = "L71VIrOS9FgBlJdJQEmzWC4v8t8=";
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            var result = modelService.GetCryptographicHash(address1, HashHelper.HashType.RIPEMD160Managed);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetCryptographicHashTest_SHA1Managed()
        {
            string expected = "AXbIepi+c310S0rpQZlCLqqCI/c=";
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            var result = modelService.GetCryptographicHash(address1, HashHelper.HashType.SHA1Managed);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetCryptographicHashTest_SHA256Managed()
        {
            string expected = "5nhaTWcLP1E/dHFt4Nf+2FHVi+9+xZE7GrkBjexsiqU=";
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            var result = modelService.GetCryptographicHash(address1, HashHelper.HashType.SHA256Managed);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetCryptographicHashTest_SHA384Managed()
        {
            string expected = "B5AGJkSVSKVJB6cwkuJqTk2IfY9sWlTKMmuZNM5pC9dIeSvGnUils0ToJ9eaJp1D";
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            var result = modelService.GetCryptographicHash(address1, HashHelper.HashType.SHA384Managed);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void GetCryptographicHashTest_SHA512Managed()
        {
            string expected = "B5AGJkSVSKVJB6cwkuJqTk2IfY9sWlTKMmuZNM5pC9dIeSvGnUils0ToJ9eaJp1D";
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };
            var result = modelService.GetCryptographicHash(address1, HashHelper.HashType.SHA512Managed);
            Assert.AreEqual(expected, result);
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
        public void GetObjectDifferencesTest_NoEmbeddedArray()
        {
            ModelService modelService = new ModelService();
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };

            //Introduce two property differes: HouseNumber and StreetName
            Address address2 = new Address() { HouseNumber = "123", StreetName = "Post Ave1", City = "Seattle", State = "WA", Zip = "98104" };

            List<Difference> properties = modelService.GetObjectDifferences(address1, address2);
            Assert.AreEqual(2, properties.Count);
            Assert.AreEqual("123", properties[0].Value2);
            Assert.AreEqual("Post Ave1", properties[1].Value2);
        }

        [TestMethod()]
        public void GetObjectDifferencesTestWithEmbeddedArray()
        {
            //While this test does not iterate into each of the embedded arrays.  The code should still detect a different
            //within the.  To do that thorough comparison would require recursion which may be beyond the scope of this test.
            //For instance there could be collections embedded within collection.  While this is do-able, I am not sure that is
            //what the customer really wants for this exercise.

            ModelService modelService = new ModelService();
            
            Address address1 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };

            //Introduce two property differes: HouseNumber and StreetName
            Address address2 = new Address() { HouseNumber = "122", StreetName = "Post Ave", City = "Seattle", State = "WA", Zip = "98104" };

            Person person1 = new Person() { FirstName = "Kurt", LastName = "Shull", Address = new List<Address>() { address1 } };
            Person person2 = new Person() { FirstName = "Kurt", LastName = "Shull", Address = new List<Address>() { address2 } };

            List<Difference> properties = modelService.GetObjectDifferences(person1, person2);
            Assert.Inconclusive();

        }
    }
}