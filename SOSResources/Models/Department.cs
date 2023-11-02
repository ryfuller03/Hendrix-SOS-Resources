using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSResources.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Author {get; set;}

        public int? Edition {get; set;}

        public int Quantity {get; set;}
        
        public int? InstructorID { get; set; }

        public Guid ConcurrencyToken { get; set; } = Guid.NewGuid();

    }
}