using System;
namespace ProblemA_ModelService
{
    public class Address
    {
       public Address()
        {
            HouseNumber = "";
            StreetName = "";
            City = "";
            State = "";
            Zip = "";
        }
        public String HouseNumber { get; set; }
        public String StreetName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }

    }
}
