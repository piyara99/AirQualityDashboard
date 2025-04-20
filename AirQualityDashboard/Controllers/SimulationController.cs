using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AirQualityDashboard.Services;

namespace AirQualityDashboard.Controllers
{
    [Authorize(Roles = "MonitoringAdmin, SystemAdmin")]
    public class SimulationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsRunning = SimulatedDataService.IsRunning;
            return View();
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
    }
}
