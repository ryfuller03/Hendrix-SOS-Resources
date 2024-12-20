using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSResources.Models
{
    public class Textbook
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [StringLength(100)]
        public string Edition { get; set; }

        public bool LoanStatus { get; set; }

        public int Quantity { get; set; }
    }
}