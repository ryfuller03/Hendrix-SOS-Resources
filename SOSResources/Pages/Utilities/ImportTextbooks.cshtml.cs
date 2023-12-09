using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.Utilities
{
    public class ImportModel : PageModel
    {
        private readonly SOSResources.Data.SOSContext _context;

        public ImportModel(SOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public Textbook[] Textbooks { get; set; }
        
        public string CSVString { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string inputCSVString)
        {
            if (String.IsNullOrEmpty(inputCSVString)){
                return Page();
            }

            string[] lines = CSVString.Split("\n");
            Console.WriteLine(lines[0]);
            if (lines[0].Contains("Title,Author")){
                lines = lines[1..^0];
            }
            Console.WriteLine(lines[0]);

            foreach (string l in lines){
                
                Textbook tb = new Textbook();
                
            }
        //   if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }
        //     _context.Textbooks.Add(Textbook);
            
        //     int.TryParse(Request.Form["copies"].ToString(), out int copies);

        //     for (int i = 0; i < copies; i++) {
        //         Copy c = new Copy{
        //             textbook = Textbook,
        //             CheckedOut = false
        //         };
        //         _context.Copies.Add(c);
        //     };

            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
