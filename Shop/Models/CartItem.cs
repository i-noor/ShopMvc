using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        // ID товара 
        public Product ProductItem { get; set; }        
        public int Quantity { get; set; }       
    }
}