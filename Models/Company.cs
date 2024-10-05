using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Models
{
    internal class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        public Company()
        {


        }
        public Company(string companyName, string location)
        {
            CompanyName = companyName;
            Location = location;
        }
    }
}
