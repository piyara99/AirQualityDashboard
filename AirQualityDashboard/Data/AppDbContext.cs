using AirQualityDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirQualityDashboard.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SimulationConfig> SimulationConfigs { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorDataRecords { get; set; }
        public DbSet<AlertThreshold> AlertThresholds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            modelBuilder.Entity<SensorData>().HasData(
    new SensorData { Id = 1, SensorId = -1, AQI = 42, Timestamp = new DateTime(2024, 04, 21, 03, 00, 00, DateTimeKind.Utc) },
    new SensorData { Id = 2, SensorId = -1, AQI = 55, Timestamp = new DateTime(2024, 04, 21, 04, 00, 00, DateTimeKind.Utc) },
    new SensorData { Id = 3, SensorId = -1, AQI = 65, Timestamp = new DateTime(2024, 04, 21, 05, 00, 00, DateTimeKind.Utc) },
    new SensorData { Id = 4, SensorId = -1, AQI = 75, Timestamp = new DateTime(2024, 04, 21, 06, 00, 00, DateTimeKind.Utc) },
    new SensorData { Id = 5, SensorId = -1, AQI = 68, Timestamp = new DateTime(2024, 04, 21, 07, 00, 00, DateTimeKind.Utc) }
);



            // Customize Identity Table Names
            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
