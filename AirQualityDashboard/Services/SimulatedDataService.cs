using AirQualityDashboard.Data;
using AirQualityDashboard.Models;

namespace AirQualityDashboard.Services
{
    public class SimulatedDataService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Random _rand = new();
        private static bool _isSimulationRunning = false;

        public SimulatedDataService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public static void StartSimulation() => _isSimulationRunning = true;
        public static void StopSimulation() => _isSimulationRunning = false;
        public static bool IsRunning => _isSimulationRunning;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_isSimulationRunning)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var sensors = db.Sensors.Where(s => s.IsActive).ToList();

                    foreach (var sensor in sensors)
                    {
                        int aqi = _rand.Next(30, 200); // Simulate AQI value
                        db.SensorDataRecords.Add(new SensorData
                        {
                            SensorId = sensor.Id,
                            AQI = aqi,
                            Timestamp = DateTime.Now
                        });
                    }

                    await db.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }



}
