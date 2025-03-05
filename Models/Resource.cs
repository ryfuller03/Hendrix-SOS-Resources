using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOSResources.Models
{
    public enum ResourceType
    {
        [Display(Name = "First Aid Supplies")]
        FirstAidSupplies,

        [Display(Name = "Over-the-Counter Medication")]
        OverTheCounterMedication,

        [Display(Name = "Hygiene Supplies")]
        HygieneSupplies,

        [Display(Name = "Personal Care Supplies")]
        PersonalCareSupplies,
        
        Textbook
    }

    public class Resource
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [StringLength(250)]
        public required string Description { get; set; }

        public int Quantity { get; set; }
    }
}