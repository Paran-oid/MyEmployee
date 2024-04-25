using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyEmployee.Data.Services;
using MyEmployee.Data.Services.EmployeeRelated;
using MyEmployee.Models;
using MyEmployee.Models.Main_Models;
using System.Security.Claims;

namespace MyEmployee.Controllers
{
    public class MainController : Controller
    {
        //we use the one below to get the current user Id and other stuff for managing current user
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeServices _employeeServices;
        private readonly IEmployeeHistoryServices _employeeHistoryServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MainController(IHttpContextAccessor httpContextAccessor,
                              UserManager<ApplicationUser> userManager,
                              IEmployeeServices employeeServices,
                              IWebHostEnvironment webHostEnvironment,
                              IEmployeeHistoryServices employeeHistoryServices)
        {
            _httpContextAccesor = httpContextAccessor;
            _userManager = userManager;
            _employeeServices = employeeServices;
            _webHostEnvironment = webHostEnvironment;
            _employeeHistoryServices = employeeHistoryServices;
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
        public async Task<IActionResult> Employees(string searchString)
        {
            //with this we will get the user Id through the dependency injection
            var userId = _httpContextAccesor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            IEnumerable<Employee> employees = _employeeServices.GetEmployees(userId);

            if(!string.IsNullOrEmpty(searchString))
            {
                employees = _employeeServices
                    .GetEmployees(userId)
                    .Where(e => e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) 
                             || e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                             || e.Profession.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

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
            if (ModelState.IsValid)
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
                    ManagerId = employee.ManagerId,
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

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var employee = await _employeeServices.GetEmployeeById(Id);
            if(employee == null)
            {
                return NotFound();
            }

            await _employeeServices.DeleteEmployee(employee);

            ViewData["Result"] = $"{employee.FirstName} was deleted";
            return RedirectToAction("Employees");
        }

        [HttpGet("Main/EditEmployee/{Id}")]
        public async Task<IActionResult> EditEmployee(int Id)
        {
            var employee = await _employeeServices.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound();
            }

            //profile picture here
            //we took user's image path first in image variable, then we openeed the file directly, then profile picture gets the new profile picture basically
            var image = Path.Combine(_webHostEnvironment.WebRootPath, "Client Added Images", employee.ProfilePicturePath);
            var profilePictureFile = System.IO.File.OpenRead(image);
            var profilePicture = new FormFile(profilePictureFile, 0, profilePictureFile.Length, null, Path.GetFileName(image));
            var employeeVM = new EmployeeVM
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ProfilePicture = profilePicture,
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
                ManagerId = employee.ManagerId,

            };
            return View("EmployeeRelated/EditEmployee", employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(int Id, EmployeeVM model)
        {
            var employee = await _employeeServices.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound();
            }

            try
            {
                var uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Client Added Images");
                if (model.ProfilePicture != null)
                {
                    //create the new file
                    string FileName = model.ProfilePicture.FileName;
                    string FilePath = Path.Combine(uploadDir, FileName);
                    if (System.IO.File.Exists(FilePath))
                    {
                        employee.ProfilePicturePath = FileName;
                    }
                    else
                    {
                        using (var fileStream = new FileStream(FilePath, FileMode.Create))
                        {
                            model.ProfilePicture.CopyTo(fileStream);
                        }
                        employee.ProfilePicturePath = FileName;
                    }
                }
                //updating employee's information
                employee.FirstName = model.FirstName ;
                employee.LastName = model.LastName;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Gender = model.Gender;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.Description = model.Description;
                employee.Salary = model.Salary;
                employee.HireDate = model.HireDate;
                employee.Profession = model.Profession;
                employee.EmploymentStatus = model.EmploymentStatus;

                //logging
                var log = new EmployeeHistory
                {
                    Action = $"{employee.FirstName} was edited",
                    Type = "Information",
                    Time = DateTime.Now,
                    EmployeeId = employee.Id
                };

                //database modification
                await _employeeHistoryServices.Log(log);
                await _employeeServices.UpdateEmployee(employee);

                //result
                TempData["Result"] = $"{employee.FirstName} was modified";
                return RedirectToAction("Employees");
            }
            catch (Exception e)
            {
                return Conflict($"{e}");
            }
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
