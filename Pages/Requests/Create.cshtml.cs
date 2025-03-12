using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HendrixSOSResources.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly SOSContext _context;

        public CreateModel(SOSContext context)
        {
            _context = context;
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
            Console.WriteLine($"IsAuthenticated: {User.Identity?.IsAuthenticated}");
            Console.WriteLine($"User Name: {User.Identity?.Name}");

            string? userEmail = User.Identity?.Name;

            var resource = await _context.Resources.FindAsync(Request.ResourceId);
            if (resource == null)
            {
                Console.WriteLine("Resource not found");
                Resources = await _context.Resources.ToListAsync();
                return Page();
            }

            Console.WriteLine($"Resource found: {resource.Name}");

            Request.Email = userEmail;
            Request.Resource = resource;

            ModelState.Remove("Request.Email");
            ModelState.Remove("Request.Resource");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid");
                Resources = await _context.Resources.ToListAsync();
                return Page();
            }

            _context.Requests.Add(Request);
            await _context.SaveChangesAsync();

            Console.WriteLine("Request saved to database");

            return RedirectToPage("./Index");
        }
    }
}
