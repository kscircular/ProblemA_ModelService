using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemA_ModelService
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelService modelService = new ModelService();

            //Return a list of properties that have different values between the two objects
            var differences = modelService.GetObjectDifferences(new List<String>(), new StringBuilder());

            //Return a list of identical properties names in each of the two objects
            var identicalProperties = modelService.GetIdenticalProperties(new List<String>(), new StringBuilder());

            //Get the Cryptographic hash for an object
            var cryptoHash = modelService.GetCryptographicHash(new List<String>(),HashHelper.HashType.SHA1Managed);

        }
    }
}
