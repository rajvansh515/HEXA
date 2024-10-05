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
    internal class JobApplicationRepository
    {
        public JobApplicationRepository()
        {

        }

        public void InsertJobApplication(JobApplication jobApplication)
        {
            try
            {
                int rowsAffected = 0;
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {

                    string query = "INSERT INTO Applications (JobID, ApplicantID, ApplicationDate, CoverLetter) " +
                                   "VALUES (@JobID, @ApplicantID, @ApplicationDate, @CoverLetter)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@JobID", jobApplication.JobID);
                        command.Parameters.AddWithValue("@ApplicantID", jobApplication.ApplicantID);
                        command.Parameters.AddWithValue("@ApplicationDate", jobApplication.ApplicationDate);
                        command.Parameters.AddWithValue("@CoverLetter", jobApplication.CoverLetter);

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

        public void GetApplicationsForJob(int jobID)
        {
            List<JobApplication> applications = new List<JobApplication>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionUtility.GetConnectionString()))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM Applications WHERE JobID = @JobID";
                        command.Parameters.AddWithValue("@JobID", jobID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                JobApplication application = new JobApplication();
                                application.ApplicationID = (int)reader["ApplicationID"];
                                application.JobID = (int)reader["JobID"];
                                application.ApplicantID = (int)reader["ApplicantID"];
                                application.ApplicationDate = (DateTime)reader["ApplicationDate"];
                                application.CoverLetter = (string)reader["CoverLetter"];
                                applications.Add(application);
                            }
                        }
                    }
                }

                foreach (JobApplication app in applications)
                {
                    Console.WriteLine(app);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
