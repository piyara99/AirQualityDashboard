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
            var sensorCount = await _context.Sensors.CountAsync();
            var activeSensors = await _context.Sensors.CountAsync(s => s.IsActive);

            var viewModel = new MonitoringDashboardViewModel
            {
                TotalSensors = sensorCount,
                ActiveSensors = activeSensors,
                SimulationRunning = Services.SimulatedDataService.IsRunning
            };

            return View(viewModel);
        }
    }
}
