using SOSResources.Models;
using SOSResources.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly SOSResources.Data.SchoolContext _context;

        public IndexModel(SOSResources.Data.SchoolContext context)
        {
            _context = context;
        }
        public IList<Instructor> Instructor { get;set; } = default!;
        public InstructorIndexData InstructorData { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            if (_context.Departments != null){
                Instructor = await _context.Instructors
                    .OrderBy(i => i.Name)
                    .ToListAsync();    
            }
            

            

            
        }
    }
}