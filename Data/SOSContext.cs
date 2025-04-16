using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public DbSet<SOSResources.Models.Resource> Resources { get; set; } = default!;
        public DbSet<SOSResources.Models.Request> Requests { get; set; } = default!;
        public DbSet<SOSResources.Models.Profile> Profiles { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>()
                .HasAlternateKey(p => p.CampusEmail);


            modelBuilder.Entity<Resource>().HasData(
                new Resource { ID = 1, Name = "Bandages", Type = ResourceType.FirstAidSupplies, Description = "Various sizes of bandages", Quantity = 100 },
                new Resource { ID = 2, Name = "Antiseptic Wipes", Type = ResourceType.FirstAidSupplies, Description = "Alcohol-based antiseptic wipes", Quantity = 200 },
                new Resource { ID = 3, Name = "Pain Relievers", Type = ResourceType.OverTheCounterMedication, Description = "Ibuprofen and acetaminophen", Quantity = 150 },
                new Resource { ID = 4, Name = "Cough Syrup", Type = ResourceType.OverTheCounterMedication, Description = "Cough suppressant syrup", Quantity = 50 },
                new Resource { ID = 5, Name = "Toothpaste", Type = ResourceType.HygieneSupplies, Description = "Fluoride toothpaste", Quantity = 75 },
                new Resource { ID = 6, Name = "Shampoo", Type = ResourceType.HygieneSupplies, Description = "Gentle shampoo for daily use", Quantity = 60 },
                new Resource { ID = 7, Name = "Deodorant", Type = ResourceType.PersonalCareSupplies, Description = "Antiperspirant deodorant", Quantity = 80 },
                new Resource { ID = 8, Name = "Lotion", Type = ResourceType.PersonalCareSupplies, Description = "Moisturizing lotion", Quantity = 90 },
                new Resource { ID = 9, Name = "Calculus Textbook", Type = ResourceType.Textbook, Description = "Advanced calculus textbook", Quantity = 30 },
                new Resource { ID = 10, Name = "Biology Textbook", Type = ResourceType.Textbook, Description = "Introductory biology textbook", Quantity = 40 }
            );
        }
    }
}
