
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyElectronicShop.Models;

namespace MyElectronicShop.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext context { get; set; }
        public HomeController(ShopContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var products = context.Product
                .Include(p => p.Type)
                .ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            ViewBag.Key = key;
            List<Product> products = context.Product.Include(p => p.Type).Where(p => p.Name.Contains(key)).ToList();
            return View("Index", products);

        }

        public IActionResult addToCart(int productId)
        {
            var UID = HttpContext.Session.GetInt32("UID");
            if (UID == null)
            {
                return RedirectToAction("signup", "Auth");
            }

            var existingItem = context.CartItem.FirstOrDefault(item => item.UserId == UID && item.PrId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                context.CartItem.Update(existingItem);

            }
            else
            {

                var cartItem = new CartItem
                {
                    UserId = UID,
                    PrId = productId,
                    Quantity = 1,
                };
                context.CartItem.Add(cartItem);
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
