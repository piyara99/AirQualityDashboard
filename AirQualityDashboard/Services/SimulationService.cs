using AirQualityDashboard.Models;
using Microsoft.EntityFrameworkCore;
using AirQualityDashboard.Data;
using Microsoft.Extensions.Logging;

namespace AirQualityDashboard.Services
{
    public class SimulationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SimulationService> _logger;

        public SimulationService(IServiceProvider serviceProvider, ILogger<SimulationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int delaySeconds = 60; // default delay if no config is found

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

                        var random = new Random();

                        foreach (var sensor in sensors)
                        {
                            var variation = random.Next(-config.VariationRange, config.VariationRange);
                            var aqi = config.BaseAQI + variation;

                            // Simulate PM2.5 and PM10 values
                            var pm25 = (float)Math.Round(random.NextDouble() * 30 + 10, 1);  // Simulating PM2.5 (e.g., 10-40 µg/m³)
                            var pm10 = (float)Math.Round(random.NextDouble() * 40 + 20, 1);  // Simulating PM10 (e.g., 20-60 µg/m³)

                            // Create the simulated data for the sensor
                            var data = new SensorData
                            {
                                SensorId = sensor.Id,
                                AQI = aqi,
                                PM25 = pm25,
                                PM10 = pm10,
                                Timestamp = DateTime.UtcNow
                            };

                            // Add the generated data to the database
                            context.SensorDataRecords.Add(data);
                        }

                        // Save all the simulated data to the database at once
                        await context.SaveChangesAsync();
                        _logger.LogInformation("Simulated data generated and saved for sensors.");
                    }
                    else
                    {
                        _logger.LogWarning("Simulation is not running or configuration is missing.");
                    }
                }

                // Wait for the configured interval before generating new data
                await Task.Delay(TimeSpan.FromSeconds(delaySeconds), stoppingToken);
            }
        }
    }
}
