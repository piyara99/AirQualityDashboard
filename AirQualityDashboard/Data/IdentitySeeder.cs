using AirQualityDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityDashboard.Data
{
    public class IdentitySeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<IdentitySeeder> _logger;

        public IdentitySeeder(
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            ILogger<IdentitySeeder> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task SeedRolesAndAdminAsync()
        {
            try
            {
                // Define system roles
                string[] roleNames = {
                    "SystemAdmin", "MonitoringAdmin",
                    "DataProvider", "PublicUser"
                };

                // Ensure all roles exist
                foreach (var roleName in roleNames)
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                        _logger.LogInformation("Created role: {Role}", roleName);
                    }
                }

                // Create system admin
                var adminEmail = "admin@air.lk";
                var adminPassword = "Admin#123";

                if (await _userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new AppUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true,
                        FullName = "System Administrator"
                    };

                    var result = await _userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRolesAsync(adminUser, new[] { "SystemAdmin", "MonitoringAdmin" });
                        _logger.LogInformation("Admin user created successfully");
                    }
                    else
                    {
                        _logger.LogError("Failed to create admin user: {Errors}",
                            string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

                // Create a Monitoring Admin
                var monitoringEmail = "monitor@air.lk";
                var monitoringPassword = "Monitor#123";

                if (await _userManager.FindByEmailAsync(monitoringEmail) == null)
                {
                    var monitoringUser = new AppUser
                    {
                        UserName = monitoringEmail,
                        Email = monitoringEmail,
                        EmailConfirmed = true,
                        FullName = "Monitoring Administrator"
                    };

                    var result = await _userManager.CreateAsync(monitoringUser, monitoringPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(monitoringUser, "MonitoringAdmin");
                        _logger.LogInformation("Monitoring admin user created successfully");
                    }
                    else
                    {
                        _logger.LogError("Failed to create monitoring admin user: {Errors}",
                            string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

            }


            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding identity data");
                throw;
            }
        }
    }
}