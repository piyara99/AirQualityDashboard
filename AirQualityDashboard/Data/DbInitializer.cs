using AirQualityDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AirQualityDashboard.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // 1. Migrate database
                await context.Database.MigrateAsync();

                // 2. Seed Roles
                string[] roles = { "SystemAdmin", "MonitoringAdmin", "PublicUser" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // 3. Seed System Admin User
                string adminEmail = "admin@airquality.com";
                string adminPassword = "Admin@123";

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "SystemAdmin");
                    }
                }

                // 4. Seed Default Alert Thresholds (only if none exist)
                // 4. Seed Default Alert Thresholds (only if none exist)
                if (!await context.AlertThresholds.AnyAsync())
                {
                    context.AlertThresholds.AddRange(
                        new AlertThreshold { CategoryName = "Good", MinAQI = 0, MaxAQI = 50, ColorHex = "#00E400" },
                        new AlertThreshold { CategoryName = "Moderate", MinAQI = 51, MaxAQI = 100, ColorHex = "#FFFF00" },
                        new AlertThreshold { CategoryName = "Unhealthy for Sensitive Groups", MinAQI = 101, MaxAQI = 150, ColorHex = "#FF7E00" },
                        new AlertThreshold { CategoryName = "Unhealthy", MinAQI = 151, MaxAQI = 200, ColorHex = "#FF0000" },
                        new AlertThreshold { CategoryName = "Very Unhealthy", MinAQI = 201, MaxAQI = 300, ColorHex = "#8F3F97" },
                        new AlertThreshold { CategoryName = "Hazardous", MinAQI = 301, MaxAQI = 500, ColorHex = "#7E0023" }
                    );

                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
