﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Models;
using MyEmployee.Models.Admin_Management;

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

        //EDIT ROLE GET ID
        [HttpGet]
        public async Task<IActionResult> EditRole(string? Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if(role == null)
            {
                return NotFound();
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
                role.Name = model.Name;
                role.Color = model.Color;
                await _roleManager.UpdateAsync(role);

                return RedirectToAction("ManageRoles");
            }
            return View(model);
        }
    }
}
