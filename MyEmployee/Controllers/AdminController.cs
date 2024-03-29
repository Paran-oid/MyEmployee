using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Models;

namespace MyEmployee.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //USERS SECTION

        //SELECT ALL USERS
        [HttpGet]
        public async Task<IActionResult> ManageUsers(string? searchString)
        {
            var roles = await _userManager.Users.ToListAsync();
            if(!string.IsNullOrEmpty(searchString))
            {
                roles = await _userManager.Users.Where(u => u.UserName.Contains(searchString)).ToListAsync();
            }
            return View(roles);
        }
        //SELECT AN ID EDIT
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        //SAVE CHANGES EDIT
        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser model)
        {
            //Find user first
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }


                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                await _userManager.UpdateAsync(user);
                return RedirectToAction("ManageUsers");
            }
            //return the user with problems to same page
            return View(model);
        }
        //SELECT AN ID DELETE
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
                    return RedirectToAction("ManageRoles");
            }
            return View(model);

        }
    }
}
