using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HendrixSOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Identity;

namespace HendrixSOSResources.Pages.Profiles
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
        public Profile Profile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Profile Data:");
            Console.WriteLine($"HendrixID: {Profile.HendrixID}");
            Console.WriteLine($"FirstName: {Profile.FirstName}");
            Console.WriteLine($"LastName: {Profile.LastName}");
            Console.WriteLine($"Email: {Profile.Email}");
            Console.WriteLine($"Classification: {Profile.Classification}");
            Console.WriteLine($"CampusAddress: {Profile.CampusAddress}");
            Console.WriteLine($"CampusEmail: {Profile.CampusEmail}");
            Console.WriteLine($"PhoneNumber: {Profile.PhoneNumber}");
            Console.WriteLine($"EmFirstName: {Profile.EmFirstName}");
            Console.WriteLine($"EmLastName: {Profile.EmLastName}");
            Console.WriteLine($"EmEmail: {Profile.EmEmail}");
            Console.WriteLine($"EmPhoneNumber: {Profile.EmPhoneNumber}");
            Console.WriteLine($"EmRelationship: {Profile.EmRelationship}");
            Console.WriteLine($"CurrentEmployer: {Profile.CurrentEmployer}");
            Console.WriteLine($"CurrentEmployerPhoneNumber: {Profile.CurrentEmployerPhoneNumber}");
            Console.WriteLine($"JobPosition: {Profile.JobPosition}");
            Console.WriteLine($"Pay: {Profile.Pay}");
            Console.WriteLine($"PayPeriod: {Profile.PayPeriod}");
            Console.WriteLine($"MonthlyWages: {Profile.MonthlyWages}");
            Console.WriteLine($"FinAidStatement: {Profile.FinAidStatement}");
            Console.WriteLine($"ReferredBy: {Profile.ReferredBy}");


            var userEmail = User.Identity?.Name;
            Profile.CampusEmail = userEmail;

            _context.Profiles.Add(Profile);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
