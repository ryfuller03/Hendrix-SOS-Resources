using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace HendrixSOSResources.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(HendrixSOSResources.Data.SOSContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Request Request { get; set; } = default!;

        public IList<Resource> Resources { get; set; } = new List<Resource>();

        public async Task OnGetAsync()
        {
            Console.WriteLine("OnGetAsync called");
            Resources = await _context.Resources.ToListAsync();
            Console.WriteLine($"Resources loaded: {Resources.Count}");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync called");

            var resource = await _context.Resources.FindAsync(Request.ResourceId);
            var user = await _userManager.GetUserAsync(User);

            if (resource == null)
            {
                Console.WriteLine("Resource not found");
                ModelState.AddModelError("Request.ResourceId", "Resource not found.");
                Resources = await _context.Resources.ToListAsync(); 
                return Page();
            }

            Console.WriteLine($"Resource found: {resource.Name}");

            Request.Resource = resource;
            Request.Email = user.Email;

            ModelState.Remove("Request.Resource");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid");
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"Field: {state.Key}, Errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                    }
                }
                Resources = await _context.Resources.ToListAsync();
                return Page();
            }

            Console.WriteLine($"Request.ResourceId: {Request.ResourceId}");

            _context.Requests.Add(Request);
            await _context.SaveChangesAsync();

            Console.WriteLine("Request saved to database");

            return Page();
        }
    }
}