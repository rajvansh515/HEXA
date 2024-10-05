using CareerHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Service;

namespace CareerHub.App
{
    internal class CareerHubManagement
    {
        public CareerHubManagement()
        {

        }

        public void App()
        {
            Console.WriteLine("Enter your role (1 : Admin, 2 : User):");
            int role = Convert.ToInt32(Console.ReadLine());

            switch (role)
            {
                case 1:
                    Console.WriteLine("Welcome Admin!");
                    AdminMenu();
                    break;
                case 2:
                    Console.WriteLine("Welcome User!");
                    UserMenu();
                    break;
                default:
                    Console.WriteLine("Invalid role!");
                    break;
            }
        }

        public static void AdminMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Admin Page:");
                Console.WriteLine("1. Insert Job Listing");
                Console.WriteLine("2. Insert Company");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        JobListingService jobListingService = new JobListingService();
                        jobListingService.InsertJobListing();
                        break;
                    case 2:
                        CompanyService companyService = new CompanyService();
                        companyService.InsertCompany();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        public static void UserMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("User Page:");
                Console.WriteLine("1. Insert an applicant");
                Console.WriteLine("2. Insert Job Application");
                Console.WriteLine("3. Get all Job Listings");
                Console.WriteLine("4. Get all Companies");
                Console.WriteLine("5. Get all Applicants");
                Console.WriteLine("6. Get Applications for Job");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ApplicantService iapplicantService = new ApplicantService();
                        iapplicantService.InsertApplicant();
                        break;
                    case 2:
                        JobApplicationService ijobApplicationService = new JobApplicationService();
                        ijobApplicationService.InsertJobApplication();
                        break;
                    case 3:
                        JobListingService jobListingService = new JobListingService();
                        jobListingService.GetJobListings();
                        break;
                    case 4:
                        CompanyService companyService = new CompanyService();
                        companyService.GetCompanies();
                        break;
                    case 5:
                        ApplicantService applicantService = new ApplicantService();
                        applicantService.GetApplicants();
                        break;
                    case 6:
                        JobApplicationService jobApplicationService = new JobApplicationService();
                        jobApplicationService.GetApplicationsForJob();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
