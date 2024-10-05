using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Models;

namespace CareerHub.Exceptions
{
    internal class InvalidSalaryException : Exception
    {
        public InvalidSalaryException(string message) : base(message)
        { 
        
        }

        public static void InvalidSalary(JobListing jobListings)
        {
            if(jobListings.Salary < 0)
            {
                throw new InvalidSalaryException("Invalid salary");
            }
        }
    }
}
