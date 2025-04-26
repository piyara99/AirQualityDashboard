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
                            .FirstOrDefault() ?? 0,
                        pm25 = _context.SensorDataRecords
                            .Where(d => d.SensorId == s.Id)
                            .OrderByDescending(d => d.Timestamp)
                            .Select(d => (double?)d.PM25)
                            .FirstOrDefault() ?? 0,
                        pm10 = _context.SensorDataRecords
                            .Where(d => d.SensorId == s.Id)
                            .OrderByDescending(d => d.Timestamp)
                            .Select(d => (double?)d.PM10)
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

        [HttpGet]
        public async Task<IActionResult> GetHourlyPm(int sensorId)
        {
            try
            {
                var now = DateTime.UtcNow;
                var past24h = now.AddHours(-23); // 24 points

                var data = await _context.SensorDataRecords
                    .Where(r => r.SensorId == sensorId && r.Timestamp >= past24h)
                    .OrderBy(r => r.Timestamp)
                    .ToListAsync();

                // Fill gaps if fewer than 24 records
                var pm25 = new List<double>();
                var pm10 = new List<double>();

                for (int i = 0; i < 24; i++)
                {
                    var hourStart = past24h.AddHours(i);
                    var hourEnd = hourStart.AddHours(1);

                    var recordsInHour = data
                        .Where(d => d.Timestamp >= hourStart && d.Timestamp < hourEnd)
                        .ToList();

                    pm25.Add(recordsInHour.Any() ? recordsInHour.Average(d => d.PM25) : 0);
                    pm10.Add(recordsInHour.Any() ? recordsInHour.Average(d => d.PM10) : 0);
                }

                return Json(new { pm25, pm10 });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching hourly PM data");
                return StatusCode(500, "Error fetching hourly PM data");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMonthlyPm(int sensorId)
        {
            try
            {
                var now = DateTime.UtcNow;
                var twelveMonthsAgo = now.AddMonths(-11);

                var data = await _context.SensorDataRecords
                    .Where(r => r.SensorId == sensorId && r.Timestamp >= twelveMonthsAgo)
                    .ToListAsync();

                var values = new List<double>();
                var labels = new List<string>();

                for (int i = 0; i < 12; i++)
                {
                    var monthStart = new DateTime(now.Year, now.Month, 1).AddMonths(-11 + i);
                    var monthEnd = monthStart.AddMonths(1);

                    var monthData = data
                        .Where(d => d.Timestamp >= monthStart && d.Timestamp < monthEnd)
                        .ToList();

                    labels.Add(monthStart.ToString("MMM"));
                    values.Add(monthData.Any() ? monthData.Average(d => d.PM25) : 0);
                }

                return Json(new { months = labels, values });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching monthly PM2.5 data");
                return StatusCode(500, "Error fetching monthly PM data");
            }
        }


    }
}
