using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyEmployee.Models;

namespace MyEmployee.Controllers
{
    public class MainController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly UserManager<ApplicationUser> _userManager;
        public MainController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccesor = httpContextAccessor;
            _userManager = userManager;
        }

        //FUNCTIONS

        public bool IsJustLoggedIn()
        {
            //we inject httpcontextaccessor, we check the context's session and get the result wether the user just logged in or not
            return _httpContextAccesor.HttpContext.Session.GetString("JustLoggedIn") == "true";
        }

        //PROGRAM
        public async Task<IActionResult> Overview()
        {
            var user = await _userManager.GetUserAsync(User);
            if (IsJustLoggedIn())
            {
                ViewData["Welcome"] = $"Welcome {user.FirstName}";
                HttpContext.Session.Remove("JustLoggedIn");
            }
            return View();

        }
        public IActionResult Employees()
        {
            return View();
        }
        public IActionResult Groups()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
    }
}
