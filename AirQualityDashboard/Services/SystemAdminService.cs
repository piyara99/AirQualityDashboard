using AirQualityDashboard.Data;
using AirQualityDashboard.Models;
using Microsoft.EntityFrameworkCore;
using AirQualityDashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirQualityDashboard.Services
{
    // Services/SystemAdminService.cs
    public class SystemAdminService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SystemAdminService> _logger;

        public SystemAdminService(AppDbContext context, ILogger<SystemAdminService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<SystemConfig>> GetAllConfigsAsync()
        {
            return await _context.SystemConfig.ToListAsync();
        }

        public async Task UpdateConfigAsync(string key, string value)
        {
            var config = await _context.SystemConfig.FirstOrDefaultAsync(c => c.ConfigKey == key);
            if (config != null)
            {
                config.ConfigValue = value;
                config.LastUpdated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Config {Key} updated to {Value}", key, value);
            }
        }

        public async Task ToggleMaintenanceModeAsync(bool enable)
        {
            await UpdateConfigAsync("MaintenanceMode", enable.ToString().ToLower());
        }
    }
}
