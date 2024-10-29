using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SOS_Resources.Areas.Identity.Data;

namespace SOSResources.Data;

public class ApplicationDbContext : IdentityDbContext<SOS_User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
