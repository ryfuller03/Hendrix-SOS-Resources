using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOSResources.Models
{
    public class Profile
    {
        [Key]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string CampusEmail { get; set; }
        public int HendrixID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Classification is required.")]
        public Class Classification { get; set; }

        [Required(ErrorMessage = "Campus Address is required.")]
        public string CampusAddress { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        // Emergency Contact
        [Display(Name = "Emergency First Name")]
        public string EmFirstName { get; set; }

        [Required(ErrorMessage = "Emergency Last Name is required.")]
        [Display(Name = "Emergency Last Name")]
        public string EmLastName { get; set; }

        [Required(ErrorMessage = "Emergency Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Emergency Email")]
        public string EmEmail { get; set; }

        [Required(ErrorMessage = "Emergency Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Emergency Phone Number")]
        public string EmPhoneNumber { get; set; }

        [Display(Name = "Emergency Relationship")]
        public string EmRelationship { get; set; }

        // Employment
        [Display(Name = "Current Employer")]
        public string CurrentEmployer { get; set; }

        [Display(Name = "Current Employer Phone Number")]
        public string CurrentEmployerPhoneNumber { get; set; }

        [Display(Name = "Job Position")]
        public string JobPosition { get; set; }

        [Required(ErrorMessage = "Pay Type is required.")]
        [Display(Name = "Pay Type")]
        public PayType Pay { get; set; }

        [Required(ErrorMessage = "Pay Period is required.")]
        [Display(Name = "Pay Period")]
        public Period PayPeriod { get; set; }

        [Display(Name = "Monthly Wages")]
        public decimal? MonthlyWages { get; set; }

        // Financial Aid
        [Display(Name = "Financial Aid Statement")]
        public string FinAidStatement { get; set; }

        [Required(ErrorMessage = "Referred By is required.")]
        [Display(Name = "Referred By")]
        public string ReferredBy { get; set; }

        // Requests
        public ICollection<Request>? Requests { get; set; }
    }

    public enum Class
    {
        Freshman,
        Sophomore,
        Junior,
        Senior,
        GraduateStudent,
        Faculty,
        Staff
    }

    public enum PayType
    {
        Hourly,
        Salary
    }

    public enum Period
    {
        Daily,
        Weekly,
        BiWeekly,
        BiMonthly,
        Monthly,
        Seasonal,
        Yearly,
        NA
    }
}