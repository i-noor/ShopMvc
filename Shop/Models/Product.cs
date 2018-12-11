using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Product
    {
        // ID товара
        public int Id { get; set; }
        // название товара
        public string Name { get; set; }
        // ссылка на изображение товара
        public string Image { get; set; }
        // количество товара
        public int Quantity { get; set; }
        // цена
        public int Price { get; set; }
    }
}