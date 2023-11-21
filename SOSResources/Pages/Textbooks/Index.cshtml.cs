using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.Textbooks
{
    public class IndexModel : PageModel
    {
        private readonly SOSResources.Data.SOSContext _context;

        public IndexModel(SOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IList<Textbook> Textbook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Textbooks != null)
            {
                Textbook = await _context.Textbooks.ToListAsync();
            }
        }
    }
}
