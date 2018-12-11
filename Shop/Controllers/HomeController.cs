using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shop.Filters;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Product> products = db.Products;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Products = products;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
        [HttpPost]
        [MyAuthAttribute]
        public string Buy(Application application)
        {
            application.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Applications.Add(application);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + application.Client.Name + ", за покупку! При необходимости наш менеджер свяжется с вами.";
        }
    }
}