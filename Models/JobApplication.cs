using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Models
{
    internal class JobApplication
    {
        public int ApplicationID { get; set; }
        public int JobID { get; set; }
        public int ApplicantID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CoverLetter { get; set; }

        public JobApplication()
        {

        }

        public JobApplication(int jobId, int applicantId, DateTime applicationDate, string coverLetter)
        {
            JobID = jobId;
            ApplicantID = applicantId;
            ApplicationDate = applicationDate;
            CoverLetter = coverLetter;
        }

        public override string ToString()
        {
            return $"ApplicationId : {ApplicationID} JobId : {JobID} ApplicantId : {ApplicantID} ApplicationDate : {ApplicationDate} CoverLetter : {CoverLetter}";
        }
    }
}
