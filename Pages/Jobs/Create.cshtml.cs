using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RRHH.Data;

namespace RRHH.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;

        public CreateModel(RRHH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public jobPosting jobPosting { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.jobPosting.Add(jobPosting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}