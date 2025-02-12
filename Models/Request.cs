using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSResources.Models
{
    public class Request
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Requester Name")]
        public required string Name { get; set; }  // Name of Requester

        [Display(Name = "Date Requested")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        public bool NeedWithinDay { get; set; }  // need within 24 hours

        [StringLength(250)]
        public required string Description { get; set; }

        public required Resource Resource { get; set; }

        public string? Notes { get; set; } // Reason for Request
    }
}