using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RRHH.Data;

namespace RRHH.Pages.applicantTest
{
    public class DeleteModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;

        public DeleteModel(RRHH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public applicant1 applicant1 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            applicant1 = await _context.applicant1.FirstOrDefaultAsync(m => m.applicantID == id);

            if (applicant1 == null)
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

            applicant1 = await _context.applicant1.FindAsync(id);

            if (applicant1 != null)
            {
                _context.applicant1.Remove(applicant1);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
