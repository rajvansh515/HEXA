using CareerHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message):base(message) 
        { 

        }

        public static void InvalidEmail(Applicant applicant)
        {
            if (!applicant.Email.Contains('@'))
            {
                throw new InvalidEmailException("Invalid email address!!!");
            }
        }
    }
}
