using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.Textbooks
{
    public class CreateModel : PageModel
    {
        private readonly SOSResources.Data.SOSContext _context;

        public CreateModel(SOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Textbook Textbook { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Textbooks.Add(Textbook);

            int.TryParse(Request.Form["copies"].ToString(), out int copies);

            Console.WriteLine("------- "+copies);

            for (int i = 0; i < copies; i++) {
                Copy c = new Copy{
                    textbook = Textbook,
                    CheckedOut = false
                };
                _context.Copies.Add(c);
            };

            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
