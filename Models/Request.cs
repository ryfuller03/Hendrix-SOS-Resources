using System.ComponentModel.DataAnnotations;

namespace SOSResources.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Display(Name = "Within 24 Hours")]
        public bool NeedWithin24Hours { get; set; }
        public string? Reason { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "ID")]

        public int ResourceId { get; set; }
        public Resource? Resource { get; set; }
    }
}