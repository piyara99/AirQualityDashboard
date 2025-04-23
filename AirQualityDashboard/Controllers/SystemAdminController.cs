using AirQualityDashboard.Models;
using AirQualityDashboard.Services;
using AirQualityDashboard.Data;
using AirQualityDashboard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirQualityDashboard.Controllers
{
    [Authorize(Roles = "SystemAdmin")]
    public class SystemAdminController : Controller
    {
        private readonly SystemAdminService _adminService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public SystemAdminController(
            SystemAdminService adminService,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            _adminService = adminService;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // Home Dashboard for System Admin
        public async Task<IActionResult> Index()
        {
            var configs = await _adminService.GetAllConfigsAsync();
            return View(configs);
        }

        // Update basic config values
        [HttpPost]
        public async Task<IActionResult> UpdateConfig(string key, string value)
        {
            await _adminService.UpdateConfigAsync(key, value);
            return RedirectToAction(nameof(Index));
        }

        // Toggle maintenance mode
        [HttpPost]
        public async Task<IActionResult> ToggleMaintenance(bool enable)
        {
            await _adminService.ToggleMaintenanceModeAsync(enable);
            return RedirectToAction(nameof(Index));
        }

        // View and manage all system users
        public async Task<IActionResult> UserManagement()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModel = new List<UserManagementViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                viewModel.Add(new UserManagementViewModel
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = string.Join(", ", roles)
                });
            }

            return View(viewModel);
        }

        // Create a new user (GET)
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        // Create a new MonitoringAdmin (POST)
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "User with this email already exists.");
                return View(model);
            }

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Ensure role exists
                if (!await _roleManager.RoleExistsAsync("MonitoringAdmin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("MonitoringAdmin"));
                }

                await _userManager.AddToRoleAsync(user, "MonitoringAdmin");

                return RedirectToAction(nameof(UserManagement));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // Delete a user
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = "User not found.";
                return RedirectToAction(nameof(UserManagement));
            }

            var result = await _userManager.DeleteAsync(user);
            TempData["Message"] = result.Succeeded ? "User deleted successfully." : "Failed to delete user.";

            return RedirectToAction(nameof(UserManagement));
        }

        // === Config Editing ===

        [HttpGet]
        public async Task<IActionResult> EditConfig(int id)
        {
            var config = await _context.SystemConfig.FindAsync(id);
            if (config == null) return NotFound();
            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> EditConfig(SystemConfig model)
        {
            if (ModelState.IsValid)
            {
                model.LastUpdated = DateTime.UtcNow;
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // === View DB Settings ===

        public IActionResult DatabaseSettings()
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            var settings = new DatabaseSettingsViewModel
            {
                ConnectionString = connectionString,
                DatabaseProvider = _context.Database.ProviderName,
                Migrations = _context.Database.GetAppliedMigrations().ToList()
            };
            return View(settings);
        }

        // === Backup DB ===

        [HttpPost]
        public async Task<IActionResult> BackupDatabase()
        {
            try
            {
                var backupPath = Path.Combine(Directory.GetCurrentDirectory(), "Backups");
                Directory.CreateDirectory(backupPath);

                var dbName = _context.Database.GetDbConnection().Database;
                var fileName = $"backup_{DateTime.Now:yyyyMMddHHmmss}.bak";
                var fullPath = Path.Combine(backupPath, fileName);

                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"BACKUP DATABASE [{dbName}] TO DISK = {fullPath}");

                TempData["Message"] = $"Backup created successfully at {fullPath}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Backup failed: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
