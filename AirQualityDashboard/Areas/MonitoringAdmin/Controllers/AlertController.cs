using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AirQualityDashboard.Data;
using AirQualityDashboard.Models;
using AirQualityDashboard.ViewModels;

namespace AirQualityDashboard.Areas.MonitoringAdmin.Controllers
{
    [Area("MonitoringAdmin")]
    [Authorize(Roles = "MonitoringAdmin, SystemAdmin")]
    public class AlertController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public AlertController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var config = await context.AlertConfig.FirstOrDefaultAsync() ?? new AlertConfig();

            var viewModel = new AlertSettingsViewModel
            {
                ModerateThreshold = config.ModerateThreshold,
                UnhealthyThreshold = config.UnhealthyThreshold
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(AlertSettingsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var config = await context.AlertConfig.FirstOrDefaultAsync();
            if (config == null)
            {
                config = new AlertConfig();
                context.AlertConfig.Add(config);
            }

            config.ModerateThreshold = model.ModerateThreshold;
            config.UnhealthyThreshold = model.UnhealthyThreshold;

            await context.SaveChangesAsync();

            TempData["Message"] = "Alert thresholds updated.";
            return RedirectToAction("Settings");
        }
    }
}
