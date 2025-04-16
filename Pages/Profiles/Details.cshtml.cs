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
    public class DetailsModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public DetailsModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public Profile Profile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FirstOrDefaultAsync(m => m.CampusEmail == id);

            if (profile is not null)
            {
                Profile = profile;

                return Page();
            }

            return NotFound();
        }
    }
}
