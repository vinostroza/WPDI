using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RRHH.Data;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Pages.applicantTest
{
    public class CreateModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermgr;

        private IHostingEnvironment _environment;

        public CreateModel(RRHH.Data.ApplicationDbContext context, UserManager<ApplicationUser> usermgr, IHostingEnvironment environment)

        {
            _environment = environment;
            _context = context;
            _usermgr = usermgr;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public applicant1 applicant1 { get; set; }

        [BindProperty]
        public ApplicationUser CurrentUser { get; set; } // new code

        [BindProperty]
        public IFormFile Upload { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentUser = await _usermgr.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            byte[] bytes;
            var files = HttpContext.Request.Form.Files;

            if (files.Any())
            {
                using (var ms = new MemoryStream())
                {
                    files[0].CopyTo(ms);
                    bytes = ms.ToArray();
                }

                string base64 = Convert.ToBase64String(bytes);
                applicant1.Upload = base64;
            }

            System.Diagnostics.Debug.WriteLine("current user: ");
            System.Diagnostics.Debug.WriteLine(CurrentUser.Id);
            applicant1.posterID = CurrentUser.Id;

            _context.applicant1.Add(applicant1);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}