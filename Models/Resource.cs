using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOSResources.Models
{
    public enum ResourceType
    {
        [Display(Name = "Food Assistance")]
        FoodAssistance,
        [Display(Name = "Personal Care Supplies")]
        PersonalCareSupplies,
        [Display(Name = "Clothing Supplies")]
        ClothingSupplies,
        [Display(Name = "School Supplies")]
        SchoolSupplies,
        [Display(Name = "Medical Assistance")]
        MedicalAssistance,
        [Display(Name = "Legal Assistance")]
        LegalAssistance,
        Transportation,
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