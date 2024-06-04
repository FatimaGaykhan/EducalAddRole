using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducalBack.Helpers.Enums;
using EducalBack.Models;
using EducalBack.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducalBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager,
                             RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            List<UserRoleVM> usersWithRoles = new();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);
                string userRoles =  String.Join(",", roles.ToArray());


                usersWithRoles.Add(new UserRoleVM
                {
                    FullName=item.FullName,
                    Username=item.UserName,
                    Email=item.Email,
                    Roles=userRoles
                });
            }
            return View(usersWithRoles);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            var users = _userManager.Users.ToList();
            ViewBag.usersSelectList = new SelectList(users, "Id", "UserName");

            var roles = _roleManager.Roles.ToList();
            ViewBag.rolesSelectList = new SelectList(roles, "Id", "Name");

            //var roleNames = _roleManager.Roles.Select(r => r.Name).ToList();

            //        var usersSelectListItems = _userManager.Users
            //.Select(u => new SelectListItem { Text = u.UserName, Value = u.Id })
            //.ToList();
            //        ViewBag.usersSelectList = new SelectList(usersSelectListItems, "Value", "Text");


            //ViewBag.usersSelectList = new SelectList(users);
            //ViewBag.rolesSelectList = new SelectList(roleNames);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(AddUserRoleVM request)
        {
            if (request is null) return BadRequest();

            var existRole = await _roleManager.FindByIdAsync(request.RoleId);
            var existUser = await _userManager.FindByIdAsync(request.UserId);

            if (existUser == null) return NotFound();

            if (existRole == null) return NotFound();

            await _userManager.AddToRoleAsync( existUser,existRole.Name);


            return RedirectToAction("Index");
        }
    }
}

