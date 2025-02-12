using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOSResources.Models;

namespace HendrixSOSResources.Data
{
    public class SOSContext : DbContext
    {
        public SOSContext (DbContextOptions<SOSContext> options)
            : base(options)
        {
        }

        public DbSet<SOSResources.Models.Request> Requests { get; set; } = default!;
        public DbSet<SOSResources.Models.Resource> Resource { get; set; } = default!;
    }
}
