using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;

namespace HendrixSOSResources.Pages.Profiles
{
    public class IndexModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public IndexModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IList<Profile> Profile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Profile = await _context.Profiles.ToListAsync();
        }
    }
}
