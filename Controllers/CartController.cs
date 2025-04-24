
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyElectronicShop.Models;

namespace ELectronicShop.Controllers
{
    public class CartController : Controller
    {
        private ShopContext context { get; set; }
        public CartController(ShopContext ctx) => context = ctx;


        public IActionResult Index()
        {

            var UID = HttpContext.Session.GetInt32("UID");
            if (UID == null)
            {
                return RedirectToAction("signup", "Auth");
            }

            var items = context.CartItem
                                     .Where(i => i.UserId == UID)
                                     .Include(i => i.Product)
                                     .ToList();

            return View(items);
        }

        public IActionResult DeleteItem(int itemId)
        {
            var item = context.CartItem.FirstOrDefault(i => i.CartItemId == itemId);
            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity >= 1)
                {
                    context.CartItem.Update(item);
                }
                else
                {
                    context.CartItem.Remove(item);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ConfirmPurchase()
        {
            var UID = HttpContext.Session.GetInt32("UID");
            if (UID == null)
            {
                return RedirectToAction("signup", "Auth");
            }


            var items = context.CartItem.Where(i => i.UserId == UID).ToList();

            foreach (CartItem item in items)
            {
                context.CartItem.Remove(item);
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
