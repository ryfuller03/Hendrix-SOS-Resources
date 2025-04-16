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

            // Example Profile 1: Student with multiple requests
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    CampusEmail = "student1@hendrix.edu",
                    HendrixID = 1001,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice.smith@email.com",
                    Classification = Class.Freshman,
                    CampusAddress = "Veasey Hall 101",
                    PhoneNumber = "501-123-4567",
                    EmFirstName = "Bob",
                    EmLastName = "Smith",
                    EmEmail = "bob.smith@email.com",
                    EmPhoneNumber = "501-987-6543",
                    EmRelationship = "Father",
                    CurrentEmployer = "null",
                    CurrentEmployerPhoneNumber = "null",
                    JobPosition = "null",
                    Pay = PayType.Hourly,
                    PayPeriod = Period.NA,
                    MonthlyWages = 15,
                    FinAidStatement = "Receiving partial financial aid.",
                    ReferredBy = "Orientation Leader"
                }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    Id = 1,
                    CampusEmail = "student1@hendrix.edu",
                    ResourceId = 1, // Bandages
                    NeedWithin24Hours = true,
                    Reason = "Scraped my knee playing intramurals.",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    Status = RequestStatus.Pending
                },
                new Request
                {
                    Id = 2,
                    CampusEmail = "student1@hendrix.edu",
                    ResourceId = 5, // Toothpaste
                    NeedWithin24Hours = false,
                    Reason = "Ran out of toothpaste.",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    Status = RequestStatus.Approved
                }
            );

            // Example Profile 2: Staff member with one request
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    CampusEmail = "staff.jones@hendrix.edu",
                    HendrixID = 2005,
                    FirstName = "Charlie",
                    LastName = "Jones",
                    Email = "charlie.jones@work.com",
                    Classification = Class.Staff,
                    CampusAddress = "Admin Building, Office 210",
                    PhoneNumber = "501-555-1212",
                    EmFirstName = "Diana",
                    EmLastName = "Jones",
                    EmEmail = "diana.jones@email.com",
                    EmPhoneNumber = "501-777-8899",
                    EmRelationship = "Spouse",
                    CurrentEmployer = "Hendrix College",
                    CurrentEmployerPhoneNumber = "501-450-1000",
                    JobPosition = "Administrative Assistant",
                    Pay = PayType.Salary,
                    PayPeriod = Period.Monthly,
                    MonthlyWages = 3500.00m,
                    FinAidStatement = "null",
                    ReferredBy = "Human Resources"
                }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    Id = 3,
                    CampusEmail = "staff.jones@hendrix.edu",
                    ResourceId = 3, // Pain Relievers
                    NeedWithin24Hours = false,
                    Reason = "Dealing with a headache.",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Status = RequestStatus.Pending
                }
            );

            // Example Profile 3: Faculty member with one request
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    CampusEmail = "prof.evans@hendrix.edu",
                    HendrixID = 3010,
                    FirstName = "Emily",
                    LastName = "Evans",
                    Email = "emily.evans@hendrix.edu",
                    Classification = Class.Faculty,
                    CampusAddress = "Ellis Hall, Room 305",
                    PhoneNumber = "501-333-9999",
                    EmFirstName = "Frank",
                    EmLastName = "Evans",
                    EmEmail = "frank.evans@email.com",
                    EmPhoneNumber = "501-222-3344",
                    EmRelationship = "Brother",
                    CurrentEmployer = "Hendrix College",
                    CurrentEmployerPhoneNumber = "501-450-1000",
                    JobPosition = "Professor of Biology",
                    Pay = PayType.Salary,
                    PayPeriod = Period.Yearly,
                    MonthlyWages = 6000.00m,
                    FinAidStatement = "null",
                    ReferredBy = "Department Chair"
                }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    Id = 4,
                    CampusEmail = "prof.evans@hendrix.edu",
                    ResourceId = 2, // Antiseptic Wipes
                    NeedWithin24Hours = false,
                    Reason = "For my lab's first aid kit.",
                    CreatedAt = DateTime.Now.AddDays(-7),
                    Status = RequestStatus.Approved
                }
            );
        }
    }
}