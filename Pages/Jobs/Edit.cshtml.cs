using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RRHH.Data;

namespace RRHH.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;

        public EditModel(RRHH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public jobPosting jobPosting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            jobPosting = await _context.jobPosting.FirstOrDefaultAsync(m => m.jobID == id);

            if (jobPosting == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(jobPosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobPostingExists(jobPosting.jobID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool jobPostingExists(int id)
        {
            return _context.jobPosting.Any(e => e.jobID == id);
        }
    }
}
