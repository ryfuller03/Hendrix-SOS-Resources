using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Resources
{
    public class DetailsModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DetailsModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public Resource Resource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource.FirstOrDefaultAsync(m => m.ID == id);
            if (resource == null)
            {
                return NotFound();
            }
            else
            {
                Resource = resource;
            }
            return Page();
        }
    }
}
