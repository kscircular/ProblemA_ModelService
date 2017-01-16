using System;
namespace ProblemA_ModelService
{
    public static class HashAlgorithm<T>
    {
        public static T GetHashAlgorithm()
        {
            var hashType = typeof(T);
            try
            {
                //check to see if the hash provided is an allowed type. If we can parse the enum then
                //the correct HashType was specified.  Otherwise the parse will thrown an exception.
                var supportedHashType = HashHelper.HashType.Parse(typeof(HashHelper.HashType), hashType.Name.ToString());
            }
            catch
            {
                throw new ApplicationException("Specified hash type is not supported.");
            }

            return Activator.CreateInstance<T>(); 
        }

    }
}
