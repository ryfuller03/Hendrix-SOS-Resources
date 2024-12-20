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
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public Textbook? TextbookItem { get; set; }

        public string? Notes { get; set; }
    }
}