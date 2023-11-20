using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOSResources.Models
{
    public class Textbook
    {
        public int ID { get; set; }
        public int TextbookID { get; set; }
        public Textbook textbook { get; set; }
        public ICollection<TextbookRequest> TextbookRequests { get; set; }
        public bool CheckedOut { get; set; }
    }
}