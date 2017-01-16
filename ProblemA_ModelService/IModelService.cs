using System.Collections.Generic;

namespace ProblemA_ModelService
{
    interface IModelService
    {
        List<Difference> GetObjectDifferences(object Object1, object Object2);
        List<string> GetIdenticalProperties(object Object1, object Object2);
        string GetCryptographicHash(object Object1,HashHelper.HashType HashType);              
    }
}
