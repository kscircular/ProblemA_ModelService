using System;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProblemA_ModelService
{
    public class HashGenerator
    {
        public string getHash(object Object, HashHelper.HashType HashType) 
        {
            //Convert object to a byte array using the binary formatter and memory stream
            var stream = new MemoryStream();

            //Create binary formatter
            var formatter = new BinaryFormatter();

            //Serialize the object into the memory stream
            formatter.Serialize(stream, Object);

            //create the byte array of the object
            var byteArray = stream.ToArray();

            Byte[] hash = null;
 
            switch (HashType.ToString())
            {
                case "MD5CryptoServiceProvider":
                    hash = HashAlgorithm<MD5CryptoServiceProvider>.GetHashAlgorithm().ComputeHash(byteArray); 
                    break;
                case "RIPEMD160Managed":
                    hash = HashAlgorithm<RIPEMD160Managed>.GetHashAlgorithm().ComputeHash(byteArray); 
                    break;
                case "SHA1Managed":
                    hash = HashAlgorithm<SHA1Managed>.GetHashAlgorithm().ComputeHash(byteArray);
                    break;
                case "SHA256Managed":
                    hash = HashAlgorithm<SHA256Managed>.GetHashAlgorithm().ComputeHash(byteArray);
                    break;
                case "SHA384Managed":
                    hash = HashAlgorithm<SHA384Managed>.GetHashAlgorithm().ComputeHash(byteArray);
                    break;
                case "SHA512Managed":
                    hash = HashAlgorithm<SHA384Managed>.GetHashAlgorithm().ComputeHash(byteArray);
                    break;
            }

            //Convert to Base64 string to be used for HTTP(REST,Request/Response)
            return Convert.ToBase64String(hash);

        }
    }
}
