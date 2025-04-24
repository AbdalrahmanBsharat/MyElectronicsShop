using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MyElectronicShop.Models;

namespace MyElectronicShop.Controllers
{
    public class AdminController : Controller
    {
        private ShopContext context { get; set; }
        public AdminController(ShopContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var UID = HttpContext.Session.GetInt32("UID");

            if (UID == null || UID != 1)
            {
                return RedirectToAction("Login", "Auth", null);
            }

            var products = context.Product.Include(p => p.Type).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add_Product()
        {
            var UID = HttpContext.Session.GetInt32("UID");

            if (UID == null || UID != 1)
            {
                return RedirectToAction("Login", "Auth", null);
            }

            ViewBag.Action = "Add";
            ViewBag.Types = context.Type.OrderBy(t => t.Name).ToList();
            return View("Update_Product", new Product());
        }

        [HttpGet]
        public IActionResult Update_Product(int id)
        {
            var UID = HttpContext.Session.GetInt32("UID");

            if (UID == null || UID != 1)
            {
                return RedirectToAction("Login", "Auth", null);
            }

            ViewBag.Action = "Edit";
            ViewBag.Types = context.Type.OrderBy(t => t.Name).ToList();
            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update_Product(Product product)
        {
            var UID = HttpContext.Session.GetInt32("UID");

            if (UID == null || UID != 1)
            {
                return RedirectToAction("Login", "Auth", null);
            }

            if (ModelState.IsValid)
            {
                if (product.PrId == 0)
                    context.Product.Add(product);
                else
                    context.Product.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Action = (product.PrId == 0) ? "Add" : "Edit";
                ViewBag.Types = context.Type.OrderBy(t => t.Name).ToList();
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete_Product(int id)
        {
            var UID = HttpContext.Session.GetInt32("UID");

            if (UID == null || UID != 1)
            {
                return RedirectToAction("Login", "Auth", null);
            }

            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete_Product(Product product)
        {
            var UID = HttpContext.Session.GetInt32("UID");

            if (UID == null || UID != 1)
            {
                return RedirectToAction("Login", "Auth", null);
            }

            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
