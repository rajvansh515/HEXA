using CareerHub.Models;
using CareerHub.Repository;
using CareerHub.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Service
{
    internal class JobListingService
    {
        JobListingRepository jobListingRepository;

        public JobListingService() 
        {
            jobListingRepository = new JobListingRepository();
        }

        public void InsertJobListing()
        {
            Console.WriteLine("Enter Company ID:");
            int companyId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Job Title:");
            string jobTitle = Console.ReadLine();

            Console.WriteLine("Enter Job Description:");
            string jobDescription = Console.ReadLine();

            Console.WriteLine("Enter Job Location:");
            string jobLocation = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Job Type:");
            string jobType = Console.ReadLine();

            Console.WriteLine("Enter Posted Date (YYYY-MM-DD):");
            DateTime postedDate = DateTime.Parse(Console.ReadLine());

            JobListing newJobListing = new JobListing(companyId, jobTitle, jobDescription, jobLocation, salary, jobType, postedDate);

            jobListingRepository.InsertJobListing(newJobListing);
            InvalidSalaryException.InvalidSalary(newJobListing);
        }

        public void GetJobListings()
        {
            List<JobListing> jobListing = new List<JobListing>();
            jobListingRepository.GetJobListings(jobListing);
        }
    }
}
