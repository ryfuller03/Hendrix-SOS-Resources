using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Profiles
{
    public class DeleteModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DeleteModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profile Profile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? email)
        {
            if (email == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FirstOrDefaultAsync(m => m.CampusEmail == email);

            if (profile is not null)
            {
                Profile = profile;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(string? email)
        {
            if (email == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FindAsync(email);
            if (profile != null)
            {
                Profile = profile;
                _context.Profiles.Remove(Profile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
