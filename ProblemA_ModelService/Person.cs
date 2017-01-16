using System;
using System.Collections.Generic;

namespace ProblemA_ModelService
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        List<Address> Address { get; set; }

        public Person()
        {
            FirstName = "";
            LastName = "";
            Address = new List<Address>();

        }
    }
}
