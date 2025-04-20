using AirQualityDashboard.Models;
using Microsoft.EntityFrameworkCore;
using AirQualityDashboard.Data;

namespace AirQualityDashboard.Services
{
    public class SimulationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public SimulationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int delaySeconds = 60; // default delay

                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var config = await context.SimulationConfigs.FirstOrDefaultAsync();

                    if (config != null && config.IsRunning)
                    {
                        delaySeconds = config.FrequencyInSeconds;

                        var sensors = await context.Sensors
                            .Where(s => s.IsActive)
                            .ToListAsync();

                        foreach (var sensor in sensors)
                        {
                            var random = new Random();
                            var variation = random.Next(-config.VariationRange, config.VariationRange);
                            var aqi = config.BaseAQI + variation;

                            var data = new SensorData
                            {
                                SensorId = sensor.Id,
                                AQI = aqi,
                                Timestamp = DateTime.UtcNow
                            };

                            context.SensorDataRecords.Add(data);
                        }

                        await context.SaveChangesAsync();
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(delaySeconds), stoppingToken);
            }
        }
    }
}
