using SOSResources.Data;
using SOSResources.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;                // For GUID in SQLite version
using System.Linq;
using System.Threading.Tasks;

namespace SOSResources.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly SOSResources.Data.SchoolContext _context;

        public EditModel(SOSResources.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }
        // Replace ViewData["InstructorID"] 
        public SelectList InstructorNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Department = await _context.Departments
                .AsNoTracking()                 // tracking not required
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (Department == null)
            {
                return NotFound();
            }

            // Use strongly typed data rather than ViewData.
            InstructorNameSL = new SelectList(_context.Instructors,
                "ID", "FirstMidName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch current department from DB.
            // ConcurrencyToken may have changed.
            var departmentToUpdate = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (departmentToUpdate == null)
            {
                return HandleDeletedDepartment();
            }

            departmentToUpdate.ConcurrencyToken = Guid.NewGuid();

            // Set ConcurrencyToken to value read in OnGetAsync
            _context.Entry(departmentToUpdate).Property(d => d.ConcurrencyToken)
                                   .OriginalValue = Department.ConcurrencyToken;

            if (await TryUpdateModelAsync<Department>(
                departmentToUpdate,
                "Department",
                s => s.Title, s => s.Author, s => s.Edition, s => s.Quantity))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Department)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. " +
                            "The department was deleted by another user.");
                        return Page();
                    }

                    var dbValues = (Department)databaseEntry.ToObject();
                    await SetDbErrorMessage(dbValues, clientValues, _context);

                    // Save the current ConcurrencyToken so next postback
                    // matches unless an new concurrency issue happens.
                    Department.ConcurrencyToken = dbValues.ConcurrencyToken;
                    // Clear the model error for the next postback.
                    ModelState.Remove($"{nameof(Department)}.{nameof(Department.ConcurrencyToken)}");
                }
            }

            InstructorNameSL = new SelectList(_context.Instructors,
                "ID", "FullName", departmentToUpdate.InstructorID);

            return Page();
        }

        private IActionResult HandleDeletedDepartment()
        {
            // ModelState contains the posted data because of the deletion error
            // and overides the Department instance values when displaying Page().
            ModelState.AddModelError(string.Empty,
                "Unable to save. The department was deleted by another user.");
            InstructorNameSL = new SelectList(_context.Instructors, "ID", "FullName", Department.InstructorID);
            return Page();
        }

        private async Task SetDbErrorMessage(Department dbValues,
                Department clientValues, SchoolContext context)
        {

            if (dbValues.Title != clientValues.Title)
            {
                ModelState.AddModelError("Department.Name",
                    $"Current value: {dbValues.Title}");
            }
            if (dbValues.Author != clientValues.Author)
            {
                ModelState.AddModelError("Department.Budget",
                    $"Current value: {dbValues.Author:c}");
            }
            if (dbValues.Edition != clientValues.Edition)
            {
                ModelState.AddModelError("Department.StartDate",
                    $"Current value: {dbValues.Edition:d}");
            }if (dbValues.Quantity != clientValues.Quantity)
            {
                ModelState.AddModelError("Department.StartDate",
                    $"Current value: {dbValues.Quantity:d}");
            }

            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit "
              + "was modified by another user after you. The "
              + "edit operation was canceled and the current values in the database "
              + "have been displayed. If you still want to edit this record, click "
              + "the Save button again.");
        }
    }
}