using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AirQualityDashboard.Services;
using AirQualityDashboard.ViewModels;
using AirQualityDashboard.Data;
using AirQualityDashboard.Models;
using Microsoft.EntityFrameworkCore;





namespace AirQualityDashboard.Areas.MonitoringAdmin.Controllers
{
    [Area("MonitoringAdmin")]
    [Authorize(Roles = "MonitoringAdmin, SystemAdmin")]


    public class SimulationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsRunning = SimulatedDataService.IsRunning;
            return View();
        }
        private readonly IServiceProvider _serviceProvider;

        public SimulationController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        [HttpPost]
        public IActionResult Start()
        {
            SimulatedDataService.StartSimulation();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Stop()
        {
            SimulatedDataService.StopSimulation();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var config = await context.SimulationConfigs.FirstOrDefaultAsync() ?? new SimulationConfig();
            var alert = await context.AlertConfig.FirstOrDefaultAsync() ?? new AlertConfig();

            var viewModel = new SimulationSettingsViewModel
            {
                FrequencyInSeconds = config.FrequencyInSeconds,
                BaseAQI = config.BaseAQI,
                VariationRange = config.VariationRange,
                AlertModerate = alert.ModerateThreshold,
                AlertUnhealthy = alert.UnhealthyThreshold
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(SimulationSettingsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var config = await context.SimulationConfigs.FirstOrDefaultAsync();
            if (config == null)
            {
                config = new SimulationConfig();
                context.SimulationConfigs.Add(config);
            }

            config.FrequencyInSeconds = model.FrequencyInSeconds;
            config.BaseAQI = model.BaseAQI;
            config.VariationRange = model.VariationRange;

            var alert = await context.AlertConfig.FirstOrDefaultAsync();
            if (alert == null)
            {
                alert = new AlertConfig();
                context.AlertConfig.Add(alert);
            }

            alert.ModerateThreshold = model.AlertModerate;
            alert.UnhealthyThreshold = model.AlertUnhealthy;

            await context.SaveChangesAsync();

            TempData["Message"] = "Simulation and alert settings updated.";
            return RedirectToAction("Settings");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConfig(SimulationConfig model)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var config = await context.SimulationConfigs.FirstOrDefaultAsync();
            if (config == null)
            {
                config = new SimulationConfig();
                context.SimulationConfigs.Add(config);
            }

            config.FrequencyInSeconds = model.FrequencyInSeconds;
            config.BaseAQI = model.BaseAQI;
            config.VariationRange = model.VariationRange;

            await context.SaveChangesAsync();

            TempData["Message"] = "Configuration updated.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DataPreview()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var latestData = await context.SensorDataRecords
                .Include(d => d.Sensor)
                .OrderByDescending(d => d.Timestamp)
                .Take(10)
                .ToListAsync();

            return View(latestData);
        }




    }
}
