using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RRHH.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace RRHH.Pages.Jobs
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermgr;

        public IndexModel(RRHH.Data.ApplicationDbContext context, UserManager<ApplicationUser> usermgr)
        {
            _context = context;
            _usermgr = usermgr;
        }

        public ApplicationUser CurrentUser { get; set; }
        public IList<jobPosting> jobPosting { get;set; }

        [BindProperty(SupportsGet = true)]
        public string jobSearch { get; set; }
        public async Task OnGetAsync()
        {
            var theJobs = from m in _context.jobPosting select m;

            if (!string.IsNullOrEmpty(jobSearch))
            {
                System.Diagnostics.Debug.WriteLine("job check");
                System.Diagnostics.Debug.WriteLine(jobSearch);
                theJobs = theJobs.Where(s => s.jobTitle.Contains(jobSearch));
            }

            jobPosting = await theJobs.ToListAsync();

            CurrentUser = await _usermgr.GetUserAsync(User);
            //jobPosting = await _context.jobPosting.ToListAsync();
        }
    }
}
