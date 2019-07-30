using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Data
{
    public class applicant1
    {
        [Key]
        [Display(Name = "Applicant ID")]
        public int applicantID { get; set; }
        [Display(Name = "First Name Only")]
        public string FNameOnly { get; set; }
        [Display(Name = "Job Interest")]
        public string jobInterest { get; set; }
        [Display(Name = "What makes me a great candidate")]
        public string whyMe { get; set; }
        [Display(Name = "Youtube embeded link of your story-video")]
        public string storyVideo { get; set; }
        [Display(Name = "PosterID")]
        public string posterID { get; set; }
        [Display(Name = "Upload Resume")]
        public string Upload { get; set; }
    }
}
