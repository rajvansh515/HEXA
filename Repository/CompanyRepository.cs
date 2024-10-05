using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Models;
using CareerHub.Service;
using CareerHub.Utility;

namespace CareerHub.Repository
{
    internal class CompanyRepository
    {
       

        public CompanyRepository()
        {

        }

        public void InsertCompany(Company company)
        {
            try
            {
                int rowsAffected = 0;
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    string query = "INSERT INTO Companies (CompanyName, Location) " +
                                   "VALUES (@CompanyName, @Location)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                        command.Parameters.AddWithValue("@Location", company.Location);

                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine($"Number of rows {rowsAffected} affected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetCompanies(List<Company> companies)
        {
            try
            {
                companies.Clear();

                string query = "SELECT * FROM Companies";
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Company company = new Company();
                                company.CompanyID = (int)reader["CompanyID"];
                                company.CompanyName = (string)reader["CompanyName"];
                                company.Location = (string)reader["Location"];

                                companies.Add(company);
                            }
                        }
                    }
                }

                foreach (Company company in companies)
                {
                    Console.WriteLine($"Company ID: {company.CompanyID}");
                    Console.WriteLine($"Company Name: {company.CompanyName}");
                    Console.WriteLine($"Location: {company.Location}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
