using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.Textbooks
{
    public class DetailsModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DetailsModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

      public Textbook Textbook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Textbooks == null)
            {
                return NotFound();
            }

            var textbook = await _context.Textbooks
                .Include(t => t.Copies)
                .ThenInclude(c => c.textbookRequests)
                .ThenInclude(r => r.Requester)
                .FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
