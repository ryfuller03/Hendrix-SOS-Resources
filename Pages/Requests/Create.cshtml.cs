using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using Microsoft.Extensions.Configuration;
using SOSResources.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOSResources;
using System.Linq.Dynamic.Core;

namespace HendrixSOSResources.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly SOSContext _context;
        private readonly IConfiguration Configuration;

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public CreateModel(SOSContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [BindProperty]
        public Request Request { get; set; } = default!;

        public PaginatedList<Resource> Resources { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name" : "";
            TypeSort = sortOrder == "Type" ? "type" : "Type";

            IQueryable<Resource> resourcesIQ = from s in _context.Resources
                                        select s;
            switch (sortOrder)
            {
                case "name":
                    resourcesIQ = resourcesIQ.OrderBy(s => s.Name);
                    break;
                case "type":
                    resourcesIQ = resourcesIQ.OrderBy(s => s.Type);
                    break;
                default:
                    resourcesIQ = resourcesIQ.OrderBy(s => s.Name);
                    break;
            }
            Console.WriteLine("OnGetAsync called");
            var pageSize = Configuration.GetValue("PageSize", 10);
            Resources = await PaginatedList<Resource>.CreateAsync(resourcesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            Console.WriteLine($"Resources loaded: {Resources.Count}");
        }

        public async Task<IActionResult> OnPostAsync(string? sortOrder, int? pageIndex)
        {
            Console.WriteLine("OnPostAsync called");
            Console.WriteLine($"IsAuthenticated: {User.Identity?.IsAuthenticated}");
            Console.WriteLine($"User Name: {User.Identity?.Name}");

            string? userEmail = User.Identity?.Name;

            var resource = await _context.Resources.FindAsync(Request.ResourceId);
            if (resource == null)
            {
                Console.WriteLine("Resource not found: " + Request.ResourceId);
                ModelState.AddModelError("Request.ResourceId", "Resource not found.");
                var pageSize = Configuration.GetValue("PageSize", 10);
                IQueryable<Resource> resourcesIQ = from s in _context.Resources
                                           select s;
                switch (sortOrder)
                {
                    case "name":
                        resourcesIQ = resourcesIQ.OrderBy(s => s.Name);
                        break;
                    case "type":
                        resourcesIQ = resourcesIQ.OrderBy(s => s.Type);
                        break;
                    default:
                        resourcesIQ = resourcesIQ.OrderBy(s => s.Name);
                        break;
                }
                Resources = await PaginatedList<Resource>.CreateAsync(resourcesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
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
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"Field: {state.Key}, Errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                    }
                }
                var pageSize = Configuration.GetValue("PageSize", 10);
                IQueryable<Resource> resourcesIQ = from s in _context.Resources
                                           select s;
                switch (sortOrder)
                {
                    case "name":
                        resourcesIQ = resourcesIQ.OrderBy(s => s.Name);
                        break;
                    case "type":
                        resourcesIQ = resourcesIQ.OrderBy(s => s.Type);
                        break;
                    default:
                        resourcesIQ = resourcesIQ.OrderBy(s => s.Name);
                        break;
                }
                Resources = await PaginatedList<Resource>.CreateAsync(resourcesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
                return Page();
            }

            _context.Requests.Add(Request);
            await _context.SaveChangesAsync();

            Console.WriteLine("Request saved to database");

            var _pageSize = Configuration.GetValue("PageSize", 10);
                IQueryable<Resource> _resourcesIQ = from s in _context.Resources
                                           select s;
                switch (sortOrder)
                {
                    case "name":
                        _resourcesIQ = _resourcesIQ.OrderBy(s => s.Name);
                        break;
                    case "type":
                        _resourcesIQ = _resourcesIQ.OrderBy(s => s.Type);
                        break;
                    default:
                        _resourcesIQ = _resourcesIQ.OrderBy(s => s.Name);
                        break;
                }
                Resources = await PaginatedList<Resource>.CreateAsync(_resourcesIQ.AsNoTracking(), pageIndex ?? 1, _pageSize);
            return Page();
        }
    }
}
