using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
    {
        db.Products.Add(new Product { Name = "Автоподставка", Image = "", Quantity = 5, Price = 220 });
        db.Products.Add(new Product { Name = "Мойка", Image = "", Quantity = 10, Price = 180 });
        db.Products.Add(new Product { Name = "Щетка", Image = "", Quantity = 1, Price = 150 });

        base.Seed(db);
    }
}
}