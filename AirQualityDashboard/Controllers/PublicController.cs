using Microsoft.AspNetCore.Mvc;
using AirQualityDashboard.Models;
using AirQualityDashboard.Data;
using Microsoft.EntityFrameworkCore;
using AirQualityDashboard.ViewModels;

namespace AirQualityMonitoring.Controllers
{
    public class PublicController : Controller
    {
        private readonly AppDbContext _context;

        public PublicController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sensors = await _context.Sensors
                .Include(s => s.SensorDataRecords)
                .ToListAsync();

            var sensorViewModels = sensors.Select(sensor => new SensorViewModel
            {
                Id = sensor.Id,
                Name = sensor.Name,
                LocationName = sensor.LocationName,
                Latitude = sensor.Latitude,
                Longitude = sensor.Longitude,
                CurrentAQI = sensor.SensorDataRecords
                    .OrderByDescending(d => d.Timestamp)
                    .FirstOrDefault()?.AQI ?? 0  // Get latest AQI or 0 if no data
            }).ToList();

            return View(sensorViewModels);
        }


        public async Task<IActionResult> SensorDetails(int id)
        {
            var sensor = await _context.Sensors
                .Include(s => s.SensorDataRecords.OrderByDescending(d => d.Timestamp).Take(24))
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sensor == null)
                return NotFound();

            return View(sensor);
        }


        // PublicController.cs
        [HttpGet]
        public async Task<IActionResult> GetAQITrendData(int id)
        {
            var sensor = await _context.Sensors
                .Include(s => s.SensorDataRecords.OrderByDescending(r => r.Timestamp).Take(24))
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sensor == null) return NotFound();

            var records = sensor.SensorDataRecords.OrderBy(r => r.Timestamp).ToList();

            return Json(new
            {
                timestamps = records.Select(r => r.Timestamp.ToString("HH:mm")),
                aqiValues = records.Select(r => r.AQI)
            });
        }

    }
}
