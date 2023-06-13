using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Authorize(Roles = clsRole.AdminRole)]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> AddRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.ToListAsync();
            if (allRoles.Any())
            {
                var rolelist = allRoles.Select(x => new RoleViewModel
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                    UseRole = userRoles.Any(y => y == x.Name)
                });
                ViewBag.UserName = user.UserName;
                ViewBag.UserId = userId;
                return View(rolelist);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoles(string userId, string jsonRoles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            List<RoleViewModel> myRoles =
                JsonConvert.DeserializeObject<List<RoleViewModel>>(jsonRoles);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.RoleName.Trim()) && !role.UseRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName.Trim());
                    }
                    if (!userRoles.Any(x => x == role.RoleName.Trim()) && role.UseRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.RoleName.Trim());
                    }
                }
                return RedirectToAction("Index");
            }
            else { return NotFound(); }
        }
    }
}
