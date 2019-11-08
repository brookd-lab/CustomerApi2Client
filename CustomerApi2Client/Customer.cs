using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerApi2Client
{
    public class CustomerTable
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public CustomerTable(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public CustomerTable() { }

    }
}