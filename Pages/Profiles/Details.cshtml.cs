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

namespace HendrixSOSResources.Pages.Profiles
{
    public class DetailsModel : PageModel
    {
        private readonly SOSContext _context;
        private IAuthorizationService _authService;

        public DetailsModel(SOSContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            _authService = authorizationService;
        }

        public Profile Profile { get; set; } = default!;
        public List<Request> Requests { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var userEmail = User.Identity?.Name;
            var isAdmin = (await _authService.AuthorizeAsync(User, "RequireAdministratorRole")).Succeeded;


            if (id != userEmail && !isAdmin)
            {
                return RedirectToPage("../Index");
            }

            Profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.CampusEmail == id);

            if (Profile == null)
            {
                return RedirectToPage("/Profiles/Create");
            }

            Requests = await _context.Requests
                .Where(r => r.CampusEmail == id)
                .Include(r => r.Resource)
                .ToListAsync();

            return Page();
        }
    }

}
