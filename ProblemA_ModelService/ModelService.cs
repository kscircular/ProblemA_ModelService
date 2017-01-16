using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemA_ModelService
{
    public class ModelService : IModelService
    {
        /// <summary>
        /// Calculate and return cryptographic hash for POCO
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public string GetCryptographicHash(object Object1, HashHelper.HashType hashType)
        {
            if (Object1 == null) throw new ArgumentException("Object1 parameter cannot be null.");  
            HashGenerator hashGenerator = new HashGenerator();                             
            return hashGenerator.GetHash(Object1,hashType);
        }

        /// <summary>
        /// Return a list of property names that exists in both POCOs.
        /// </summary>
        /// <param name="Object1"></param>
        /// <param name="Object2"></param>
        /// <returns></returns>
        public List<String> GetIdenticalProperties(object Object1, object Object2)
        {
            if (Object1 == null) throw new ArgumentException("Object1 parameter cannot be null.");
            if (Object2 == null) throw new ArgumentException("Object2 parameter cannot be null.");
            
            var result = new List<String>();

            try
            {
                var queryResult = from p1 in Object1.GetType().GetProperties().AsEnumerable()
                                  join p2 in Object2.GetType().GetProperties().AsEnumerable() 
                                  on p1.Name equals p2.Name
                                  select p1.Name;

                result = queryResult.ToList<String>();
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected exception encountered",ex);
            }
            return result;
        }

        /// <summary>
        /// Return a list of differences that exits between two POCOs
        /// </summary>
        /// <param name="Object1"></param>
        /// <param name="Object2"></param>
        /// <returns></returns>
        public List<Difference> GetObjectDifferences(object Object1, object Object2)
        {
            if (Object1 == null) throw new ArgumentException("Object1 parameter cannot be null.");
            if (Object2 == null) throw new ArgumentException("Object2 parameter cannot be null.");

            var result = new List<Difference>();

            try
            {
                var queryResult = from p1 in Object1.GetType().GetProperties().AsEnumerable()
                                  join p2 in Object2.GetType().GetProperties().AsEnumerable() on p1.Name equals p2.Name
                                  where p1.GetValue(Object1, null) != p2.GetValue(Object2, null)
                                  select new Difference() { Name = p1.Name, Value1 = p1.GetValue(Object1, null).ToString(), Value2 = p2.GetValue(Object2, null).ToString() };

                result = queryResult.ToList<Difference>();
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected exception encountered", ex);
            }

            return result;
        }
    }
}
