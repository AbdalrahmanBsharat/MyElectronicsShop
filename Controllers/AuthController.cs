
using Microsoft.AspNetCore.Mvc;
using MyElectronicShop.Models;

namespace MyElectronicShop.Controllers
{
    public class AuthController : Controller
    {
        private ShopContext context { get; set; }
        public AuthController(ShopContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {

            var existingUser = context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Email = user.Email.Trim().ToLower(),
                    Password = user.Password.Trim(),
                    Username = user.Username
                };
                context.Users.Add(newUser);
                context.SaveChanges();
                HttpContext.Session.SetInt32("UID", newUser.UserId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == pass);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UID", user.UserId);

                if (user.UserId == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var UID = HttpContext.Session.GetInt32("UID");
            if (UID != null)
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == UID);
                return View(user);
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Update(user);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);
            }
        }
    }
}
