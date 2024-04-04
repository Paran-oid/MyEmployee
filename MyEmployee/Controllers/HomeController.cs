using Microsoft.AspNetCore.Mvc;
using MyEmployee.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyEmployee.Models.STI_functions;

namespace MyEmployee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        //STI PROJECT

        //GET ITEM
        [HttpGet]
        public IActionResult STI()
        {
            try
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "files", "Buttons.txt");
                string fileContent = System.IO.File.ReadAllText(filePath);
                string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                return View(lines);
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error has occured loading the buttons";
                return View();
            }
        }

        
        public JsonResult STISO(string button, string value)
        {
            var operation = new FunctionsJs();

            string res = "";
            switch (button)
            {
                case "Premier":
                    res = operation.Premier(value).ToString();
                    break;
                case "Palindrome":
                    res = operation.Palindrome(value).ToString();
                    break;
                case "Factoriel":
                    res = operation.Factoriel(value).ToString();
                    break;
                //ADD REST OF CASES
            }
            return Json(new { result = res });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
