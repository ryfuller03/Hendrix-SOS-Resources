using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SOSResources.Data;
using SOSResources.Models;

namespace SOSResources.Pages.Textbooks
{
    public class IndexModel : PageModel
    {
        private readonly SOSResources.Data.SOSContext _context;

        public IndexModel(SOSResources.Data.SOSContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string TitleFilter { get; set; }
        public string AuthorFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Textbook> Textbook { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string titleSearchString, string authorSearchString)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "Author" ? "author_desc" : "Author";
            TitleFilter = titleSearchString;
            AuthorFilter = authorSearchString;

            IQueryable<Textbook> TextbookIQ = from tb in _context.Textbooks
                                            select tb;

            if (!String.IsNullOrEmpty(authorSearchString) && !String.IsNullOrWhiteSpace(titleSearchString))
            {
                TextbookIQ = TextbookIQ.Where(tb => tb.Author.Contains(authorSearchString)
                                && tb.Title.Contains(titleSearchString));
            } else if (!String.IsNullOrWhiteSpace(titleSearchString)){
                TextbookIQ = TextbookIQ.Where(tb => tb.Title.Contains(titleSearchString));
            } else if (!String.IsNullOrWhiteSpace(authorSearchString)){
                TextbookIQ = TextbookIQ.Where(tb => tb.Author.Contains(authorSearchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    TextbookIQ = TextbookIQ.OrderByDescending(tb => tb.Title);
                    break;
                case "Author":
                    TextbookIQ = TextbookIQ.OrderBy(tb => tb.Author);
                    break;
                case "author_desc":
                    TextbookIQ = TextbookIQ.OrderByDescending(tb => tb.Author);
                    break;
                default:
                    TextbookIQ = TextbookIQ.OrderBy(tb => tb.Title);
                    break;
            }

            if (_context.Textbooks != null)
            {
                Textbook = await TextbookIQ.Include(t => t.Copies).ToListAsync();
            }
        }
    }
}
