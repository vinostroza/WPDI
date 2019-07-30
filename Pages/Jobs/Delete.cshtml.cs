using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RRHH.Data;

namespace RRHH.Pages.Jobs
{
    public class DeleteModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;

        public DeleteModel(RRHH.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            jobPosting = await _context.jobPosting.FindAsync(id);

            if (jobPosting != null)
            {
                _context.jobPosting.Remove(jobPosting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
