using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> OnPostApproveAsync(int id) 
        { 
            var request = await _context.Requests.FindAsync(id); 
            if (request == null) 
            { 
                return NotFound(); 
            } 
 
            request.Status = RequestStatus.Approved; 
            _context.Update(request); 
            await _context.SaveChangesAsync(); 
 
            return RedirectToPage(); 
        } 
 
        public async Task<IActionResult> OnPostDenyAsync(int id) 
        { 
            var request = await _context.Requests.FindAsync(id); 
            if (request == null) 
            { 
                return NotFound(); 
            } 
 
            request.Status = RequestStatus.Denied; 
            _context.Update(request); 
            await _context.SaveChangesAsync(); 
 
            return RedirectToPage(); 
        } 
    }
}