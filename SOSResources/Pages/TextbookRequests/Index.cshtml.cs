using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.TextbookRequests
{
    public class IndexModel : PageModel
    {
        private readonly SOSResources.Data.SOSContext _context;

        public IndexModel(SOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IList<TextbookRequest> TextbookRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TextbookRequests != null)
            {
                TextbookRequest = await _context.TextbookRequests.Include(r => r.Requester).ToListAsync();
            }
        }
    }
}
