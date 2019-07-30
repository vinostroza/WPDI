using System.ComponentModel.DataAnnotations;

namespace RRHH.Data
{
    public class jobPosting
    {
        [Key]
        [Display(Name = "Job ID")]
        public int jobID { get; set; }
        [Display(Name = "Company")]
        public string company { get; set; }
        [Display(Name = "Culture")]
        public string companyCulture { get; set; }
        [Display(Name = "Job Title")]
        public string jobTitle { get; set; }
        [Display(Name = "Job Description")]
        public string jobDescription { get; set; }
        [Display(Name = "Work Hours")]
        public string workHours { get; set; }
        [Display(Name = "Salary Range")]
        public string salaryRange { get; set; }
        [Display(Name = "Benefits")]
        public string benefits { get; set; }
       
    }
}
