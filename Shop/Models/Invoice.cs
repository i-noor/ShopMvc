using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        // ID товара        
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        
        public DateTime Date { get; set; }
        public int Cost { get; set; }
    }
}