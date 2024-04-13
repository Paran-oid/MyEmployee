using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyEmployee.Data.Services;
using MyEmployee.Models;
using MyEmployee.Models.Main_Models;

namespace MyEmployee.Controllers
{
    public class MainController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeServices _employeeServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MainController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IEmployeeServices employeeServices, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccesor = httpContextAccessor;
            _userManager = userManager;
            _employeeServices = employeeServices;
            _webHostEnvironment = webHostEnvironment;
        }

        //FUNCTIONS

        public bool IsJustLoggedIn()
        {
            //we inject httpcontextaccessor, we check the context's session and get the result wether the user just logged in or not
            return _httpContextAccesor.HttpContext.Session.GetString("JustLoggedIn") == "true";
        }

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

        //EMPLOYEES SECTION

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var employees = _employeeServices.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View("EmployeeRelated/AddEmployee");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeVM employee)
        {
            if (employee.ProfilePicture != null)
            {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Client Added Images");
                if(!Directory.Exists(UploadDir))
                {
                    Directory.CreateDirectory(UploadDir);
                }
                string FileName = employee.ProfilePicture.FileName;
                string FilePath = Path.Combine(UploadDir, FileName);

                using(var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    employee.ProfilePicture.CopyTo(fileStream);
                }

                var newEmployee = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    ProfilePicturePath = FileName, 
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender,
                    Address = employee.Address,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Description = employee.Description,
                    Salary = employee.Salary,
                    HireDate = employee.HireDate,
                    Profession = employee.Profession,
                    EmploymentStatus = employee.EmploymentStatus,
                    ManagerId = employee.ManagerId
                };

                await _employeeServices.AddEmployee(newEmployee);

                return RedirectToAction("Employees") ;
            }
            return View("EmployeeRelated/AddEmployee", employee);
        }

        [HttpGet("Main/Employees/{Id}")]
        public async Task<IActionResult> AboutEmployee(int Id)
        {
            var employee = await _employeeServices.GetEmployeeById(Id);

            if (employee == null)
            {
                return NotFound();
            }
            return View("EmployeeRelated/AboutEmployee", employee);
        }

        //GROUPS SECTION
        public IActionResult Groups()
        {
            return View();
        }

        //PROJECTS SECTION
        public IActionResult Projects()
        {
            return View();
        }
    }
}
