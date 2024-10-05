using CareerHub.Exceptions;
using CareerHub.Models;
using CareerHub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Service
{
    internal class JobApplicationService
    {
        JobApplicationRepository jobApplicationRepository;

        public JobApplicationService()
        {
            jobApplicationRepository = new JobApplicationRepository();
        }

        public void InsertJobApplication()
        {
            try
            {
                Console.WriteLine("Enter Job ID:");
                int jobId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Applicant ID:");
                int applicantId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Application Date (YYYY-MM-DD HH:MM:SS):");
                DateTime applicationDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter the deadline for application");
                DateTime deadline = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Cover Letter:");
                string coverLetter = Console.ReadLine();

                ApplicationDeadlineException.ApplicationDeadLine(applicationDate,deadline);
                JobApplication newJobApplication = new JobApplication(jobId, applicantId, applicationDate, coverLetter);

                jobApplicationRepository.InsertJobApplication(newJobApplication);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetApplicationsForJob()
        {
            Console.WriteLine("Enter Job ID:");
            int jobId = Convert.ToInt32(Console.ReadLine());
            jobApplicationRepository.GetApplicationsForJob(jobId);
        }
    }
}
