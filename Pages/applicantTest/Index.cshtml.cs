using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RRHH.Data;
using Microsoft.AspNetCore.Authorization;

namespace RRHH.Pages.applicantTest
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
        public IList<applicant1> applicant1 { get;set; }

        
        public async Task OnGetAsync()
        {
            CurrentUser = await _usermgr.GetUserAsync(User);

            if (User.Identity.IsAuthenticated)
            { 
            //run a query
            //create a queryable variable
            IQueryable<applicant1> applicantPosts = from m in _context.applicant1 select m;
            //query using where clause (similar to sql)
            applicantPosts = applicantPosts.Where(m => m.posterID.Contains(CurrentUser.Id));
            // Execute query in database and retrieve results
            applicant1 = await applicantPosts.AsNoTracking().ToListAsync();
            }

            else 
            {
                applicant1 = await _context.applicant1.ToListAsync();

            }
        }

    }
}
