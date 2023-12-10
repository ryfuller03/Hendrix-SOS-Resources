using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SOS_Resources.Areas.Identity.Data;

namespace SOS_Resources.Data;

public class ApplicationDbContext : IdentityDbContext<SOS_User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
