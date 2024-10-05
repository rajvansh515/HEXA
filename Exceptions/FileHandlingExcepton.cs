using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
    internal class FileHandlingExcepton : Exception
    {
        public FileHandlingExcepton(string message) : base(message) { }

        public static void  FileExcepton(string resume)
        {
            if (!resume.Contains("."))
            {
                throw new FileHandlingExcepton("Inappropriae File Name");
            }
        }
    }
}
