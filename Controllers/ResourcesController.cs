using Microsoft.AspNetCore.Mvc;
using SOSResources.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HendrixSOSResources.Data;

namespace SOSResources.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly SOSContext _context;

        public ResourcesController(SOSContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/resources")]
        public async Task<IActionResult> GetResources()
        {
            var resources = await _context.Resource.ToListAsync();
            return Ok(resources);
        }
    }
}