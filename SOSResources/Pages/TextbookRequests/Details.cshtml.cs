using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.TextbookRequests
{
    public class DetailsModel : PageModel
    {
        private readonly SOSResources.Data.SOSContext _context;

        public DetailsModel(SOSResources.Data.SOSContext context)
        {
            _context = context;
        }

      public TextbookRequest TextbookRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TextbookRequests == null)
            {
                return NotFound();
            }

            var textbookrequest = await _context.TextbookRequests.FirstOrDefaultAsync(m => m.ID == id);
            if (textbookrequest == null)
            {
                return NotFound();
            }
            else 
            {
                TextbookRequest = textbookrequest;
            }
            return Page();
        }
    }
}
