using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Requests
{
    public class DetailsModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DetailsModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public Request Request { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }
            else
            {
                Request = request;
            }
            return Page();
        }
    }
}
