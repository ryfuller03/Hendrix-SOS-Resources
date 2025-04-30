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
        
        [BindProperty(SupportsGet = true)]
        public ResourceType? SelectedType { get; set; }

        public CreateModel(SOSContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public class RequestInputModel
        {
            public bool IsSelected { get; set; }
            public int ResourceId { get; set; }
            public string? Reason { get; set; }
            public bool NeedWithin24Hours { get; set; }
        }


        [BindProperty]
        public List<RequestInputModel> Requests { get; set; } = new();


        public PaginatedList<Resource> Resources { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder, int? pageIndex)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name" : "";
            TypeSort = sortOrder == "Type" ? "type" : "Type";

            IQueryable<Resource> resourcesIQ = from s in _context.Resources
                                            select s;

            if (SelectedType.HasValue)
            {
                resourcesIQ = resourcesIQ.Where(r => r.Type == SelectedType.Value);
                Console.WriteLine($"Filtering by type: {SelectedType.Value}");
            }
            
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
            var userEmail = User.Identity?.Name;
            var hasProfile = await _context.Profiles.AnyAsync(p => p.CampusEmail == userEmail);
                if (!hasProfile)
                {
                    return RedirectToPage("/Profiles/Create");
                }

            var pageSize = Configuration.GetValue("PageSize", 10);
            Resources = await PaginatedList<Resource>.CreateAsync(resourcesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            Console.WriteLine($"Resources loaded: {Resources.Count}");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? sortOrder, int? pageIndex)
        {
            Console.WriteLine("OnPostAsync called");
            var userEmail = User.Identity?.Name;

            if (!await _context.Profiles.AnyAsync(p => p.CampusEmail == userEmail))
            {
                return RedirectToPage("/Profiles/Create");
            }

            var selectedRequests = Requests.Where(r => r.IsSelected).ToList();

            if (!selectedRequests.Any())
            {
                await LoadResourcesAsync(sortOrder, pageIndex);
                return Page();
            }

            foreach (var req in selectedRequests)
            {
                var resource = await _context.Resources.FindAsync(req.ResourceId);
                if (resource == null) continue;

                var request = new Request
                {
                    CampusEmail = userEmail!,
                    ResourceId = resource.ID,
                    Reason = req.Reason,
                    NeedWithin24Hours = req.NeedWithin24Hours,
                    CreatedAt = DateTime.Now,
                    Status = RequestStatus.Pending
                };

                _context.Requests.Add(request);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Profiles/Details", new { id = userEmail.ToString()});
        }

        private async Task LoadResourcesAsync(string? sortOrder, int? pageIndex)
        {
            IQueryable<Resource> resourcesIQ = from s in _context.Resources select s;

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

            var pageSize = Configuration.GetValue("PageSize", 10);
            Resources = await PaginatedList<Resource>.CreateAsync(resourcesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


    }
}
