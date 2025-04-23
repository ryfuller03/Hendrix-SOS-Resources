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
        private readonly SOSContext _context;

        public DetailsModel(SOSContext context)
        {
            _context = context;
        }

        public Profile Profile { get; set; } = default!;
        public List<Request> Requests { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.CampusEmail == id);

            if (Profile == null)
            {
                return NotFound();
            }

            Requests = await _context.Requests
                .Where(r => r.CampusEmail == id)
                .Include(r => r.Resource)
                .ToListAsync();

            return Page();
        }
    }

}
