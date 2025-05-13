using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Authorization;

namespace HendrixSOSResources.Pages.Resources
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class DeleteModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DeleteModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resource Resource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resources.FindAsync(id);
            if (resource != null)
            {
                Resource = resource;
                _context.Resources.Remove(Resource);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
