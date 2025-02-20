using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOSResources.Models
{
    public enum ResourceType
    {
        FirstAidSupplies,
        OverTheCounterMedication,
        HygieneSupplies,
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

        public ICollection<Request> Requests { get; set; }
    }
}