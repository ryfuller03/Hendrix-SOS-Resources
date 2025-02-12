using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSResources.Models
{
    public class Resource
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(30)]
        public required string Type { get; set; }

        [StringLength(250)]
        public required string Description { get; set; }

        public int Quantity { get; set; }

        public bool IsTextbook { get; set; }

        public string? Notes { get; set; }
    }
}