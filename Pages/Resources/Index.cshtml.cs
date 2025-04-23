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
    public class IndexModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public IndexModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IList<Resource> Resource { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public ResourceType? SelectedType { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Resource> resources = _context.Resources;

            if (SelectedType.HasValue)
            {
                resources = resources.Where(r => r.Type == SelectedType.Value);
            }

            Resource = await resources.ToListAsync();
        }
    }
}