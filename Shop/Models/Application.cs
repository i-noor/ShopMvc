using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Application
    {
        public int Id { get; set; }
        // ID клиента        
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        // ID товара 
        public List<Product> ProductList { get; set; }
        //public int? ProductId { get; set; }
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
        public DateTime Date { get; set; }
    }
}