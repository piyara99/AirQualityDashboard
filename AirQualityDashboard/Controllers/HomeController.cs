using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // <-- Make sure this is here
using AirQualityDashboard.Data;
using Microsoft.AspNetCore.Authorization;

namespace AirQualityDashboard.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger; // <-- Add this

        public HomeController(AppDbContext context, ILogger<HomeController> logger) // <-- Inject it
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var sensors = await _context.Sensors.ToListAsync();
            return View(sensors);
        }

        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            try
            {
                var sensors = await _context.Sensors
                    .Where(s => s.IsActive)
                    .Select(s => new
                    {
                        id = s.Id,
                        name = s.Name,
                        latitude = s.Latitude,
                        longitude = s.Longitude,
                        aqi = _context.SensorDataRecords
                            .Where(d => d.SensorId == s.Id)
                            .OrderByDescending(d => d.Timestamp)
                            .Select(d => (int?)d.AQI)
                            .FirstOrDefault() ?? 0
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return Ok(sensors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting sensors");
                return StatusCode(500, new
                {
                    error = "Failed to load sensor data",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAqiHistory(int sensorId, int days = 1)
        {
            try
            {
                var startDate = DateTime.Now.AddDays(-days);
                var endDate = DateTime.Now;

                var history = await _context.SensorDataRecords
                    .Where(d => d.SensorId == sensorId &&
                                d.Timestamp >= startDate &&
                                d.Timestamp <= endDate)
                    .OrderBy(d => d.Timestamp)
                    .Select(d => new
                    {
                        date = d.Timestamp.ToString(days == 1 ? "HH:mm" : "MM/dd"),
                        aqi = d.AQI
                    })
                    .ToListAsync();

                return Json(new
                {
                    dates = history.Select(h => h.date),
                    aqiValues = history.Select(h => h.aqi)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting AQI history");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
