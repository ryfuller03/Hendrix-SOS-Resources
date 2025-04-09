using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using System.Threading.Tasks;

namespace SOS_Resources.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GraphMailService _mailService;

        public IndexModel(ILogger<IndexModel> logger, GraphMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSendEmailAsync()
        {
            Console.WriteLine("OnPostSendEmailAsync is called");
            await _mailService.SendAsync(
                "allened@hendrix.edu",
                "Test",
                "It worked!"
            );

            Console.WriteLine("OnPostSendEmailAsync is finished");
            return new JsonResult(new { success = true });
        }
    }
}