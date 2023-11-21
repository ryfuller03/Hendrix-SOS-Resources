using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSResources.Models
{
    public class Copy
    {
        public int ID { get; set; }
        [Required]
        public Textbook textbook { get; set; }
        public TextbookRequest activeRequest { get; set;}
        public ICollection<TextbookRequest> textbookRequests { get; set; }
        public bool CheckedOut { get; set; }
    }
}