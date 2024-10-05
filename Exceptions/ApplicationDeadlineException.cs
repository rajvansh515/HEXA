using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
    internal class ApplicationDeadlineException : Exception
    {
        public ApplicationDeadlineException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public static void ApplicationDeadLine(DateTime applicationDate, DateTime deadline)
        {

            if (applicationDate > deadline)
            {
                throw new ApplicationDeadlineException("Application deadline has passed. Application is no longer accepted.");
            }
        }
    }
}
