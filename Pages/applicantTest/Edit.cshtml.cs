using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RRHH.Data;

namespace RRHH.Pages.applicantTest
{
    public class EditModel : PageModel
    {
        private readonly RRHH.Data.ApplicationDbContext _context;

        public EditModel(RRHH.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(applicant1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!applicant1Exists(applicant1.applicantID))
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

        private bool applicant1Exists(int id)
        {
            return _context.applicant1.Any(e => e.applicantID == id);
        }
    }
}
