using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Authorization;

namespace HendrixSOSResources.Pages.Resources
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class CreateModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public required SelectList ResourceTypeList { get; set; }

        public CreateModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ResourceTypeList = new SelectList(Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>());
            return Page();
        }

        [BindProperty]
        public Resource Resource { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _context.Resources.Add(Resource);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
