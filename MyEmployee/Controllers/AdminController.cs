using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Data;
using MyEmployee.Data.Services;
using MyEmployee.Models;
using MyEmployee.Models.Admin_Management;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyEmployee.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogServices _logServices;

        public AdminController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, ILogServices logServices)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logServices = logServices;

        }
        //INDEX PAGE
        public IActionResult Index()
        {
            return View();
        }

        //USERS SECTION

        //SELECT ALL USERS
        [HttpGet]
        public async Task<IActionResult> ManageUsers(string? searchString)
        {
            var users = await _userManager.Users.ToListAsync();
            if(!string.IsNullOrEmpty(searchString))
            {
                users = await _userManager.Users.Where(u => u.UserName.Contains(searchString)).ToListAsync();
            }
            return View(users);
        }
        //EDIT USER GET
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var editModel = new ApplicationUserEditADMIN()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };

            return View(editModel);
        }
        //EDIT USER POST
        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUserEditADMIN model)
        {
            //Find user first
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = string.IsNullOrWhiteSpace(model.FirstName) ? user.FirstName : model.FirstName;
                user.LastName = string.IsNullOrWhiteSpace(model.LastName) ? user.LastName : model.LastName;
                user.UserName = string.IsNullOrWhiteSpace(model.Username) ? user.UserName : model.UserName;
                user.PhoneNumber = string.IsNullOrWhiteSpace(model.PhoneNumber) ? user.PhoneNumber : model.PhoneNumber;
                user.Email = string.IsNullOrWhiteSpace(model.Email) ? user.Email : model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _logServices.LogInformationAsync($"{user.UserName} was edited", User.Identity.Name);
                    TempData["message"] = "Changes has been saved!";
                    return RedirectToAction("ManageUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            //return the user with problems to same page
            return View(model);
        }
        //DELETE USER
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _logServices.LogInformationAsync($"{user.UserName} was deleted", User.Identity.Name);
                TempData["deleted"] = $"{user.UserName} was deleted successfully";
                return RedirectToAction("ManageUsers");
            }
            return View("ManageUsers");
        }
        //ROLES SECTION

        //SELECT ALL ROLES
        [HttpGet]
        public async Task<IActionResult> ManageRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        //CREATE ROLE GET 
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        //CREATE ROLE POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateRole(ApplicationRole model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole()
                {
                    Name = model.Name,
                    Color = model.Color
                };
                await _roleManager.CreateAsync(role);
                if (string.IsNullOrEmpty(role.Name))
                {
                    return BadRequest();
                }
                await _logServices.LogInformationAsync($"{role.Name} was created", User.Identity.Name);
                TempData["message"] = $"{role.Name} was created";
                return RedirectToAction("ManageRoles");
            }
            return View(model);
        }

        //EDIT ROLE GET ID
        [HttpGet]
        public async Task<IActionResult> EditRole(string? Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if(role == null)
            {
                return NotFound();
            }
            if ((role.Name == "Admin" || role.Name == "Manager" || role.Name == "User") && User.IsInRole("Admin"))
            {
                return Unauthorized();
            }
            return View(role);
        }

        //EDIT ROLE POST ID
        [HttpPost]
        public async Task<IActionResult> EditRole(ApplicationRole model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if( role == null)
                {
                    return NotFound();
                }

                role.Name = string.IsNullOrEmpty(model.Name) ? role.Name : model.Name;
                role.Color = model.Color;
                await _roleManager.UpdateAsync(role);
                await _logServices.LogInformationAsync($"{role.Name} was modified", User.Identity.Name);
                TempData["editmessage"] = $"{role.Name} was modified";
                return RedirectToAction("ManageRoles");
            }
            return View(model);
        }

        //DELETE ROLE POST 
        public async Task<IActionResult> DeleteRole(string? Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                return NotFound();
            }
            if ((role.Name == "Admin" || role.Name == "Manager" || role.Name == "User") && User.IsInRole("Admin"))
            {
                return Unauthorized();
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                await _logServices.LogInformationAsync($"{role.Name} was deleted", User.Identity.Name);
                TempData["deletemessage"] = $"{role.Name} was deleted";
                return RedirectToAction("ManageRoles");
            }
            return View("EditRole");
        }



        //ADD ADMIN 

        //ADD ADMIN GET 
        [Authorize(Roles ="Manager")]

        [HttpGet]
        public IActionResult AddRemAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        //ADD ADMIN POST
        [HttpPost]
        public async Task<IActionResult> AddRemAdmin(string action, ApplicationUser model)
        {
            //WE CHECK IF THE USER EXISTS
            string? temp = model.Id?.Trim();

            var user = await _userManager.FindByIdAsync(temp);

            if(user == null)
            {
                return NotFound();
            }
            
            if (action == "add")
            {
                //WE CHECK HIS CURRENT ROLES AND SEE IF HE IS ALREADY AN ADMIN
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                {
                    ModelState.AddModelError("", "User is already an admin");
                    return View(model);
                }

                //WE ADD THE USER
                var result = await _userManager.AddToRoleAsync(user, "Admin");

                if (result.Succeeded)
                {
                    await _logServices.LogWarningAsync($"{user.FirstName} was added to admins", User.Identity.Name);
                    TempData["message"] = $"{user.FirstName} was added to admins";
                    return RedirectToAction("Index");
                }
                //IF WE FACE ANY PROBLEM WE SHOW THE ERRORS
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else if (action == "remove" )
            {
                var roles = await _userManager.GetRolesAsync(user);
                //WE CHECK IF HE DOESNT HAVE THE ADMIN ROLE
                if (!roles.Contains("Admin"))
                {
                    ModelState.AddModelError("", "User is not an admin");
                    return View(model);
                }
                //WE REMOVE THE USER
                var result = await _userManager.RemoveFromRoleAsync(user, "Admin");

                if (result.Succeeded)
                {
                    await _logServices.LogWarningAsync($"{user.UserName} was removed from admins", User.Identity.Name);
                    TempData["message"] = $"{user.UserName} was removed from admins";
                    return RedirectToAction("Index");
                }
                //IF WE FACE ANY PROBLEM WE SHOW THE ERRORS
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        // LOGS
        public async Task<IActionResult> AuditLogs()
        {
            var logs = _logServices.GetAll();
            return View(logs);
        }
    }
}
