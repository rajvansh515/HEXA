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
    internal class ApplicantService
    {
        ApplicantRepository applicantRepository;

        public ApplicantService()
        {
            applicantRepository = new ApplicantRepository();
        }

        public void InsertApplicant()
        {
            try
            {
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter Email:");
                string email = Console.ReadLine();

                Console.WriteLine("Enter Phone Number:");
                string phone = Console.ReadLine();

                Console.WriteLine("Enter Resume:");
                string resume = Console.ReadLine();

                FileHandlingExcepton.FileExcepton(resume);

                Applicant newApplicant = new Applicant(firstName, lastName, email, phone, resume);

                applicantRepository.InsertApplicant(newApplicant);

                InvalidEmailException.InvalidEmail(newApplicant);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();
            applicantRepository.GetApplicants(applicants);
        }
    }
}
