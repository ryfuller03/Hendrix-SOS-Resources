using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Textbooks
{
    public class IndexModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public IndexModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IList<Textbook> Textbook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Textbook = await _context.Textbooks.ToListAsync();
        }
    }
}
