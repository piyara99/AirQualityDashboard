using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirQualityDashboard.Data;
using System.Threading.Tasks;
using System.Linq;
using AirQualityDashboard.ViewModels;


namespace AirQualityDashboard.Controllers
{
    [Authorize(Roles = "MonitoringAdmin, SystemAdmin")]
    public class MonitoringAdminController : Controller
    {
        private readonly AppDbContext _context;

        public MonitoringAdminController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var sensors = await _context.Sensors.ToListAsync();

            var sensorData = await _context.SensorDataRecords
                .GroupBy(d => d.SensorId)
                .Select(g => g.OrderByDescending(d => d.Timestamp).FirstOrDefault())
                .ToListAsync();

            var alertConfig = await _context.AlertConfig.FirstOrDefaultAsync();
            var moderateThreshold = alertConfig?.ModerateThreshold ?? 100;
            var unhealthyThreshold = alertConfig?.UnhealthyThreshold ?? 150;

            var topSensors = sensorData
                .OrderByDescending(d => d.AQI)
                .Take(3)
                .Select(d =>
                {
                    var sensor = sensors.FirstOrDefault(s => s.Id == d.SensorId);
                    return new MonitoringDashboardViewModel.Sensor
                    {
                        Name = sensor?.Name ?? "Unknown",
                        AirQualityIndex = d.AQI,
                        IsActive = sensor?.IsActive ?? false,
                        Type = sensor?.Type ?? "Unknown",
                        LastUpdated = d.Timestamp
                    };
                }).ToList();

            var last7Days = Enumerable.Range(0, 7)
                .Select(i => DateTime.UtcNow.Date.AddDays(-i))
                .Reverse()
                .ToList();

            var dailyUpdates = last7Days
                .Select(day => sensorData.Count(d => d.Timestamp.Date == day))
                .ToList();

            var sensorTypeCounts = sensors
                .GroupBy(s => s.Type)
                .ToDictionary(g => g.Key, g => g.Count());

            var model = new MonitoringDashboardViewModel
            {
                TotalSensors = sensors.Count,
                ActiveSensors = sensors.Count(s => s.IsActive),
                AverageAirQualityIndex = sensorData.Any() ? sensorData.Average(d => d.AQI) : 0,
                LastUpdateTime = sensorData.Any() ? sensorData.Max(d => d.Timestamp) : DateTime.MinValue,
                HealthySensors = sensorData.Count(d => d.AQI < moderateThreshold),
                WarningSensors = sensorData.Count(d => d.AQI >= moderateThreshold && d.AQI < unhealthyThreshold),
                CriticalSensors = sensorData.Count(d => d.AQI >= unhealthyThreshold),
                TopSensors = topSensors,
                SensorTypeCounts = sensorTypeCounts,
                Last7Days = last7Days,
                DailySensorUpdates = dailyUpdates,
                SimulationRunning = Services.SimulatedDataService.IsRunning
            };

            return View(model);
        }

    }
}
