using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Textbooks
{
    public class DeleteModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DeleteModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Textbook Textbook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var textbook = await _context.Textbooks.FirstOrDefaultAsync(m => m.ID == id);

            if (textbook == null)
            {
                return NotFound();
            }
            else
            {
                Textbook = textbook;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var textbook = await _context.Textbooks.FindAsync(id);
            if (textbook != null)
            {
                Textbook = textbook;
                _context.Textbooks.Remove(Textbook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
