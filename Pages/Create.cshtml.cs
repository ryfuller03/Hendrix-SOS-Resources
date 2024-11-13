using System;
using System.Collections.Generic;//doesnt exist?
using System.Collections; //newly added
using System.Data; //newly added
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // doesnt exist?
using Microsoft.IdentityModel.Tokens;
using HendrixSOSResources.Data;
using System.IO; //newly added
using SOSResources.Models;
using static System.Linq.Queryable;
using System.Linq.Dynamic.Core; //newly added


namespace SOSResources.Pages.Textbooks
{
    public class CreateModel : PageModel
    {
        private readonly HendrixSOSResources.Data.SOSContext _context;

        public CreateModel(HendrixSOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Textbook Textbook { get; set; }
        

        public int Copies { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int copies)
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            //Check if the textbook already exists and only create it if not.
            var matches = _context.Textbooks.Where(t => t.Title.ToUpper().Equals(Textbook.Title.ToUpper()) && t.Author.ToUpper().Equals(Textbook.Author.ToUpper()));
            Textbook tb = null;
            if (matches != null){ //WE ARE NO LONGER USING ISNULLOREMPTY, BUG CHECK THIS?
                if (Textbook.Edition == null){
                    var editionMatch = matches.Where(t => String.IsNullOrWhiteSpace(t.Edition));
                    if (editionMatch != null){
                        tb = editionMatch.ToArray()[0];
                    }
                } else {
                    var editionMatch = matches.Where(t => t.Edition.Equals(Textbook.Edition));
                    if (editionMatch != null){
                        tb = editionMatch.ToArray()[0];
                    }
                }
            }

            if (tb == null){
                _context.Textbooks.Add(Textbook);
            } else {
                Textbook = tb;
            }

            
            //int.TryParse(Request.Form["copies"].ToString(), out int copies);

            // for (int i = 0; i < copies; i++) {
            //     Copy c = new Copy{
            //         textbook = Textbook,
            //         CheckedOut = false
            //     };
            //     _context.Copies.Add(c);
            // };

            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
