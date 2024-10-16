using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SOS_Resources.Pages;

public class RequestModel : PageModel
{
    private readonly ILogger<RequestModel> _logger;

    public RequestModel(ILogger<RequestModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

