using System;
using System.Collections.Generic;

namespace ProblemA_ModelService
{
    [Serializable]
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public List<Address> Address { get; set; }

        public Person()
        {
            FirstName = "";
            LastName = "";
            Address = new List<Address>();

        }
    }
}
