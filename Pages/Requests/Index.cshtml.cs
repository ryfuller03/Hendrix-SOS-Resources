using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Requests
{
    public class IndexModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public IndexModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IList<Request> Requests { get; set; } = new List<Request>();

        public async Task OnGetAsync()
        {
            Requests = await _context.Requests
                .Include(r => r.Resource)
                .ToListAsync();
        }
    }
}