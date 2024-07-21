using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuanLyHocSinh.Models;
using System.Diagnostics;

namespace QuanLyHocSinh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string welcomeMessage = TempData["WelcomeMessage"] as string;

            ViewData["WelcomeMessage"] = welcomeMessage;

            TempData["WelcomeMessage"] = null;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (IsValidUser(model.Username, model.Password))
            {
                TempData["WelcomeMessage"] = $"Chào mừng, {model.Username}!";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Sai thông tin đăng nhập");
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private bool IsValidUser(string username, string password)
        {
            return username == "admin" && password == "123";
        }

    }
}
