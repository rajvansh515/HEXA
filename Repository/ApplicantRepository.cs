using CareerHub.Models;
using CareerHub.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repository
{
    internal class ApplicantRepository
    {
        public ApplicantRepository() 
        { 

        }

        public void InsertApplicant(Applicant applicant)
        {
            try
            {
                int rowsAffected = 0;
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    string query = "INSERT INTO Applicants (FirstName, LastName, Email, Phone, Resume) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Phone, @Resume)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                        command.Parameters.AddWithValue("@LastName", applicant.LastName);
                        command.Parameters.AddWithValue("@Email", applicant.Email);
                        command.Parameters.AddWithValue("@Phone", applicant.Phone);
                        command.Parameters.AddWithValue("@Resume", applicant.Resume);

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

        public void GetApplicants(List<Applicant> applicants)
        {
            try
            {
                applicants.Clear();
                string query = "SELECT * FROM Applicants";

                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Applicant applicant = new Applicant();
                                applicant.ApplicantID = (int)reader["ApplicantID"];
                                applicant.FirstName = (string)reader["FirstName"];
                                applicant.LastName = (string)reader["LastName"];
                                applicant.Email = (string)reader["Email"];
                                applicant.Phone = (string)reader["Phone"];
                                applicant.Resume = (string)reader["Resume"];
                                applicants.Add(applicant);
                            }
                        }
                    }
                }

                foreach (Applicant applicant in applicants)
                {
                    Console.WriteLine($"Applicant ID: {applicant.ApplicantID}");
                    Console.WriteLine($"First Name: {applicant.FirstName}");
                    Console.WriteLine($"Last Name: {applicant.LastName}");
                    Console.WriteLine($"Email: {applicant.Email}");
                    Console.WriteLine($"Phone: {applicant.Phone}");
                    Console.WriteLine($"Resume: {applicant.Resume}");
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
