using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Models;
using CareerHub.Utility;
using CareerHub.Exceptions;

namespace CareerHub.Repository
{
    internal class JobListingRepository
    {
        public JobListingRepository() { }

        public void InsertJobListing(JobListing jobListing)
        {
            try
            {
                int rowsaffected = 0;
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    // Define the SQL query with parameters
                    string query = "INSERT INTO Jobs (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                                   "VALUES (@CompanyID, @Jobtitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CompanyID", jobListing.CompanyID);
                        command.Parameters.AddWithValue("@Jobtitle", jobListing.JobTitle);
                        command.Parameters.AddWithValue("@JobDescription", jobListing.JobDescription);
                        command.Parameters.AddWithValue("@JobLocation", jobListing.JobLocation);
                        command.Parameters.AddWithValue("@Salary", jobListing.Salary);
                        command.Parameters.AddWithValue("@JobType", jobListing.JobType);
                        command.Parameters.AddWithValue("@PostedDate", jobListing.PostedDate);

                        connection.Open();

                        rowsaffected = command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine($"Number of rows {rowsaffected} affected");
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Database Connectivity error");
            }

        }

        public void GetJobListings(List<JobListing> jobListing)
        {
            try
            {
                jobListing.Clear();

                string query = "SELECT * FROM JOBS";

                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                   
                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                JobListing listing = new JobListing();
                                listing.JobID = (int)reader["JobID"];
                                listing.CompanyID = (int)reader["CompanyID"];
                                listing.JobTitle = (string)reader["JobTitle"];
                                listing.JobDescription = (string)reader["JobDescription"];
                                listing.JobLocation = (string)reader["JobLocation"];
                                listing.Salary = (decimal)reader["Salary"];
                                listing.JobType = (string)reader["JobType"];
                                listing.PostedDate = (DateTime)reader["PostedDate"];

                                jobListing.Add(listing);
                            }
                        }
                    }
                }

                foreach (JobListing listing in jobListing)
                {
                    Console.WriteLine($"Job ID: {listing.JobID}");
                    Console.WriteLine($"Company ID: {listing.CompanyID}");
                    Console.WriteLine($"Job Title: {listing.JobTitle}");
                    Console.WriteLine($"Job Description: {listing.JobDescription}");
                    Console.WriteLine($"Job Location: {listing.JobLocation}");
                    Console.WriteLine($"Salary: {listing.Salary}");
                    Console.WriteLine($"Job Type: {listing.JobType}");
                    Console.WriteLine($"Posted Date: {listing.PostedDate}");
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
