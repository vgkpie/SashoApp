using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SashoApp.Models;
using SashoApp.Models.Roles;  // Ако имаш класове, свързани с роли

namespace SashoApp.Controllers
{
    [Authorize(Roles = "Admin")]  // Само администратори могат да използват този контролер
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // Показване на всички роли
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();  // Вземаме всички роли
            return View(roles);
        }

        // Формуляр за създаване на нова роля
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Обработване на създаването на нова роля
        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("", "Моля, въведете име на роля.");
                return View();
            }

            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));  // Създаване на нова роля
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Ролята вече съществува.");
            return View();
        }

        // Присвояване на роля на потребител
        [HttpGet]
        public async Task<IActionResult> AssignRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            ViewBag.UserRoles = userRoles;
            ViewBag.AllRoles = roles;
            return View(user);
        }

        // Обработване на присвояването на роля на потребител
        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                ModelState.AddModelError("", "Ролята не съществува.");
                return View(user);
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);  // Присвояваме ролята
                return RedirectToAction("Index", "Users");  // Пренасочване към списъка с потребители
            }

            ModelState.AddModelError("", "Потребителят вече има тази роля.");
            return View(user);
        }
    }
}
