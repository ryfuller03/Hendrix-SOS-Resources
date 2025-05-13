using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Authorization;

namespace HendrixSOSResources.Pages.Resources
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class EditModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public required SelectList ResourceTypeList { get; set; }

        public EditModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resource Resource { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource =  await _context.Resources.FirstOrDefaultAsync(m => m.ID == id);
            if (resource == null)
            {
                return NotFound();
            }
            ResourceTypeList = new SelectList(Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>());
            Resource = resource;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Resource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceExists(Resource.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResourceExists(int id)
        {
            return _context.Resources.Any(e => e.ID == id);
        }
    }
}
