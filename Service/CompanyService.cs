using CareerHub.Models;
using CareerHub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Service
{
    internal class CompanyService
    {
        CompanyRepository companyRepository;

        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }

        public void InsertCompany()
        {
            Console.WriteLine("Enter Company Name:");
            string companyName = Console.ReadLine();

            Console.WriteLine("Enter Company Location:");
            string location = Console.ReadLine();

            Company newCompany = new Company(companyName, location);

            companyRepository.InsertCompany(newCompany);
        }

        public void GetCompanies()
        {
            List<Company> companies = new List<Company>();
            companyRepository.GetCompanies(companies);
        }
    }
}
