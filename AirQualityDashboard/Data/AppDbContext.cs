using AirQualityDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirQualityDashboard.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SystemConfig> SystemConfig { get; set; }

        public DbSet<SimulationConfig> SimulationConfigs { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorDataRecords { get; set; }
        public DbSet<AlertThreshold> AlertThresholds { get; set; }

        public DbSet<AlertConfig> AlertConfig { get; set; }

        public DbSet<AQIReading> AQIReadings { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var seedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Seed Sensors
            modelBuilder.Entity<Sensor>().HasData(
                new Sensor { Id = -1, Name = "Colombo Central", LocationName = "Colombo Central", Latitude = 6.9271, Longitude = 79.8612, IsActive = true, SensorIndex = 12345 },
                new Sensor { Id = -2, Name = "Colombo North", LocationName = "Colombo North", Latitude = 6.9714, Longitude = 79.8662, IsActive = true, SensorIndex = 67890 },
                new Sensor { Id = -3, Name = "Colombo South", LocationName = "Colombo South", Latitude = 6.8825, Longitude = 79.8886, IsActive = true, SensorIndex = 13579 }
            );

            // Seed SimulationConfig
            modelBuilder.Entity<SimulationConfig>().HasData(
                new SimulationConfig
                {
                    Id = 1,
                    IsRunning = true,
                    BaseAQI = 100,
                    FrequencyInSeconds = 60,
                    VariationRange = 20
                }
            );

            // 🔥 Seed SensorDataRecords (dummy AQI data)
            var baseTime = new DateTime(2024, 4, 21, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<SensorData>().HasData(
                new SensorData { Id = 1, SensorId = -1, AQI = 45, PM25 = 12.3f, PM10 = 22.1f, Timestamp = baseTime.AddHours(0) },
                new SensorData { Id = 2, SensorId = -1, AQI = 48, PM25 = 13.1f, PM10 = 23.4f, Timestamp = baseTime.AddHours(1) },
                new SensorData { Id = 3, SensorId = -1, AQI = 52, PM25 = 14.8f, PM10 = 25.9f, Timestamp = baseTime.AddHours(2) },
                new SensorData { Id = 4, SensorId = -1, AQI = 55, PM25 = 16.0f, PM10 = 28.4f, Timestamp = baseTime.AddHours(3) },
                new SensorData { Id = 5, SensorId = -1, AQI = 60, PM25 = 17.3f, PM10 = 30.2f, Timestamp = baseTime.AddHours(4) },
                new SensorData { Id = 6, SensorId = -1, AQI = 63, PM25 = 18.5f, PM10 = 31.7f, Timestamp = baseTime.AddHours(5) },
                new SensorData { Id = 7, SensorId = -1, AQI = 67, PM25 = 19.2f, PM10 = 32.5f, Timestamp = baseTime.AddHours(6) },
                new SensorData { Id = 8, SensorId = -1, AQI = 70, PM25 = 20.0f, PM10 = 34.1f, Timestamp = baseTime.AddHours(7) },
                new SensorData { Id = 9, SensorId = -1, AQI = 72, PM25 = 21.1f, PM10 = 35.8f, Timestamp = baseTime.AddHours(8) },
                new SensorData { Id = 10, SensorId = -1, AQI = 75, PM25 = 22.4f, PM10 = 37.3f, Timestamp = baseTime.AddHours(9) },
                new SensorData { Id = 11, SensorId = -1, AQI = 78, PM25 = 23.2f, PM10 = 39.0f, Timestamp = baseTime.AddHours(10) },
                new SensorData { Id = 12, SensorId = -1, AQI = 80, PM25 = 24.0f, PM10 = 40.2f, Timestamp = baseTime.AddHours(11) },
                new SensorData { Id = 13, SensorId = -1, AQI = 82, PM25 = 24.8f, PM10 = 41.9f, Timestamp = baseTime.AddHours(12) },
                new SensorData { Id = 14, SensorId = -1, AQI = 79, PM25 = 23.5f, PM10 = 40.7f, Timestamp = baseTime.AddHours(13) },
                new SensorData { Id = 15, SensorId = -1, AQI = 76, PM25 = 22.1f, PM10 = 38.9f, Timestamp = baseTime.AddHours(14) },
                new SensorData { Id = 16, SensorId = -1, AQI = 70, PM25 = 20.4f, PM10 = 35.7f, Timestamp = baseTime.AddHours(15) },
                new SensorData { Id = 17, SensorId = -1, AQI = 68, PM25 = 19.6f, PM10 = 34.2f, Timestamp = baseTime.AddHours(16) },
                new SensorData { Id = 18, SensorId = -1, AQI = 66, PM25 = 18.8f, PM10 = 32.9f, Timestamp = baseTime.AddHours(17) },
                new SensorData { Id = 19, SensorId = -1, AQI = 62, PM25 = 17.5f, PM10 = 30.4f, Timestamp = baseTime.AddHours(18) },
                new SensorData { Id = 20, SensorId = -1, AQI = 58, PM25 = 16.2f, PM10 = 28.3f, Timestamp = baseTime.AddHours(19) },
                new SensorData { Id = 21, SensorId = -1, AQI = 55, PM25 = 15.1f, PM10 = 26.5f, Timestamp = baseTime.AddHours(20) },
                new SensorData { Id = 22, SensorId = -1, AQI = 50, PM25 = 14.0f, PM10 = 24.2f, Timestamp = baseTime.AddHours(21) },
                new SensorData { Id = 23, SensorId = -1, AQI = 47, PM25 = 13.2f, PM10 = 23.0f, Timestamp = baseTime.AddHours(22) },
                new SensorData { Id = 24, SensorId = -1, AQI = 44, PM25 = 12.5f, PM10 = 21.7f, Timestamp = baseTime.AddHours(23) }
            );

            modelBuilder.Entity<SensorData>().HasData(
    new SensorData { Id = 25, SensorId = -2, AQI = 38, PM25 = 10.1f, PM10 = 18.5f, Timestamp = baseTime.AddHours(0) },
    new SensorData { Id = 26, SensorId = -2, AQI = 40, PM25 = 11.2f, PM10 = 19.9f, Timestamp = baseTime.AddHours(1) },
    new SensorData { Id = 27, SensorId = -2, AQI = 43, PM25 = 12.0f, PM10 = 20.8f, Timestamp = baseTime.AddHours(2) },
    new SensorData { Id = 28, SensorId = -2, AQI = 47, PM25 = 13.5f, PM10 = 22.3f, Timestamp = baseTime.AddHours(3) },
    new SensorData { Id = 29, SensorId = -2, AQI = 52, PM25 = 14.8f, PM10 = 24.0f, Timestamp = baseTime.AddHours(4) },
    new SensorData { Id = 30, SensorId = -2, AQI = 54, PM25 = 15.5f, PM10 = 25.2f, Timestamp = baseTime.AddHours(5) },
    new SensorData { Id = 31, SensorId = -2, AQI = 59, PM25 = 16.7f, PM10 = 27.4f, Timestamp = baseTime.AddHours(6) },
    new SensorData { Id = 32, SensorId = -2, AQI = 62, PM25 = 17.6f, PM10 = 29.0f, Timestamp = baseTime.AddHours(7) },
    new SensorData { Id = 33, SensorId = -2, AQI = 65, PM25 = 18.9f, PM10 = 30.1f, Timestamp = baseTime.AddHours(8) },
    new SensorData { Id = 34, SensorId = -2, AQI = 68, PM25 = 19.7f, PM10 = 31.4f, Timestamp = baseTime.AddHours(9) },
    new SensorData { Id = 35, SensorId = -2, AQI = 70, PM25 = 20.5f, PM10 = 32.8f, Timestamp = baseTime.AddHours(10) },
    new SensorData { Id = 36, SensorId = -2, AQI = 72, PM25 = 21.2f, PM10 = 34.3f, Timestamp = baseTime.AddHours(11) },
    new SensorData { Id = 37, SensorId = -2, AQI = 71, PM25 = 20.9f, PM10 = 33.5f, Timestamp = baseTime.AddHours(12) },
    new SensorData { Id = 38, SensorId = -2, AQI = 69, PM25 = 20.0f, PM10 = 32.2f, Timestamp = baseTime.AddHours(13) },
    new SensorData { Id = 39, SensorId = -2, AQI = 66, PM25 = 19.2f, PM10 = 30.7f, Timestamp = baseTime.AddHours(14) },
    new SensorData { Id = 40, SensorId = -2, AQI = 63, PM25 = 18.0f, PM10 = 29.1f, Timestamp = baseTime.AddHours(15) },
    new SensorData { Id = 41, SensorId = -2, AQI = 60, PM25 = 17.1f, PM10 = 27.5f, Timestamp = baseTime.AddHours(16) },
    new SensorData { Id = 42, SensorId = -2, AQI = 57, PM25 = 16.0f, PM10 = 25.9f, Timestamp = baseTime.AddHours(17) },
    new SensorData { Id = 43, SensorId = -2, AQI = 54, PM25 = 15.0f, PM10 = 24.3f, Timestamp = baseTime.AddHours(18) },
    new SensorData { Id = 44, SensorId = -2, AQI = 50, PM25 = 13.9f, PM10 = 22.7f, Timestamp = baseTime.AddHours(19) },
    new SensorData { Id = 45, SensorId = -2, AQI = 46, PM25 = 12.7f, PM10 = 21.0f, Timestamp = baseTime.AddHours(20) },
    new SensorData { Id = 46, SensorId = -2, AQI = 42, PM25 = 11.3f, PM10 = 19.2f, Timestamp = baseTime.AddHours(21) },
    new SensorData { Id = 47, SensorId = -2, AQI = 39, PM25 = 10.6f, PM10 = 18.0f, Timestamp = baseTime.AddHours(22) },
    new SensorData { Id = 48, SensorId = -2, AQI = 37, PM25 = 9.8f, PM10 = 17.1f, Timestamp = baseTime.AddHours(23) }
);

            modelBuilder.Entity<SensorData>().HasData(
    new SensorData { Id = 49, SensorId = -3, AQI = 60, PM25 = 16.2f, PM10 = 26.3f, Timestamp = baseTime.AddHours(0) },
    new SensorData { Id = 50, SensorId = -3, AQI = 62, PM25 = 17.0f, PM10 = 27.5f, Timestamp = baseTime.AddHours(1) },
    new SensorData { Id = 51, SensorId = -3, AQI = 65, PM25 = 18.1f, PM10 = 28.9f, Timestamp = baseTime.AddHours(2) },
    new SensorData { Id = 52, SensorId = -3, AQI = 68, PM25 = 19.3f, PM10 = 30.1f, Timestamp = baseTime.AddHours(3) },
    new SensorData { Id = 53, SensorId = -3, AQI = 72, PM25 = 20.6f, PM10 = 31.7f, Timestamp = baseTime.AddHours(4) },
    new SensorData { Id = 54, SensorId = -3, AQI = 75, PM25 = 21.5f, PM10 = 33.4f, Timestamp = baseTime.AddHours(5) },
    new SensorData { Id = 55, SensorId = -3, AQI = 78, PM25 = 22.3f, PM10 = 35.2f, Timestamp = baseTime.AddHours(6) },
    new SensorData { Id = 56, SensorId = -3, AQI = 80, PM25 = 23.1f, PM10 = 36.8f, Timestamp = baseTime.AddHours(7) },
    new SensorData { Id = 57, SensorId = -3, AQI = 83, PM25 = 24.4f, PM10 = 38.2f, Timestamp = baseTime.AddHours(8) },
    new SensorData { Id = 58, SensorId = -3, AQI = 85, PM25 = 25.2f, PM10 = 39.6f, Timestamp = baseTime.AddHours(9) },
    new SensorData { Id = 59, SensorId = -3, AQI = 88, PM25 = 26.3f, PM10 = 41.0f, Timestamp = baseTime.AddHours(10) },
    new SensorData { Id = 60, SensorId = -3, AQI = 90, PM25 = 27.0f, PM10 = 42.3f, Timestamp = baseTime.AddHours(11) },
    new SensorData { Id = 61, SensorId = -3, AQI = 87, PM25 = 26.0f, PM10 = 41.2f, Timestamp = baseTime.AddHours(12) },
    new SensorData { Id = 62, SensorId = -3, AQI = 84, PM25 = 24.9f, PM10 = 39.4f, Timestamp = baseTime.AddHours(13) },
    new SensorData { Id = 63, SensorId = -3, AQI = 81, PM25 = 23.7f, PM10 = 37.8f, Timestamp = baseTime.AddHours(14) },
    new SensorData { Id = 64, SensorId = -3, AQI = 78, PM25 = 22.5f, PM10 = 36.0f, Timestamp = baseTime.AddHours(15) },
    new SensorData { Id = 65, SensorId = -3, AQI = 75, PM25 = 21.2f, PM10 = 33.9f, Timestamp = baseTime.AddHours(16) },
    new SensorData { Id = 66, SensorId = -3, AQI = 72, PM25 = 20.1f, PM10 = 32.3f, Timestamp = baseTime.AddHours(17) },
    new SensorData { Id = 67, SensorId = -3, AQI = 69, PM25 = 19.0f, PM10 = 30.6f, Timestamp = baseTime.AddHours(18) },
    new SensorData { Id = 68, SensorId = -3, AQI = 65, PM25 = 17.9f, PM10 = 28.8f, Timestamp = baseTime.AddHours(19) },
    new SensorData { Id = 69, SensorId = -3, AQI = 62, PM25 = 16.5f, PM10 = 26.7f, Timestamp = baseTime.AddHours(20) },
    new SensorData { Id = 70, SensorId = -3, AQI = 59, PM25 = 15.3f, PM10 = 25.0f, Timestamp = baseTime.AddHours(21) },
    new SensorData { Id = 71, SensorId = -3, AQI = 55, PM25 = 14.1f, PM10 = 23.5f, Timestamp = baseTime.AddHours(22) },
    new SensorData { Id = 72, SensorId = -3, AQI = 52, PM25 = 13.0f, PM10 = 22.0f, Timestamp = baseTime.AddHours(23) }
);





            // Customize Identity Table Names
            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            modelBuilder.Entity<SystemConfig>().HasData(
        new SystemConfig
        {
            Id = 1,
            ConfigKey = "SystemName",
            ConfigValue = "Air Quality Dashboard",
            Description = "Name of the application",
            LastUpdated = seedDate
        },
        new SystemConfig
        {
            Id = 2,
            ConfigKey = "MaintenanceMode",
            ConfigValue = "false",
            Description = "Whether system is in maintenance mode",
            LastUpdated = seedDate
        }
    );
        }
    }
}
