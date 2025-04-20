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

            // Configure your seed data
            modelBuilder.Entity<Sensor>().HasData(
                new Sensor { Id = -1, Name = "Colombo Central", LocationName = "Colombo Central", Latitude = 6.9271, Longitude = 79.8612, IsActive = true, SensorIndex = 12345 },
                new Sensor { Id = -2, Name = "Colombo North", LocationName = "Colombo North", Latitude = 6.9714, Longitude = 79.8662, IsActive = true, SensorIndex = 67890 },
                new Sensor { Id = -3, Name = "Colombo South", LocationName = "Colombo South", Latitude = 6.8825, Longitude = 79.8886, IsActive = true, SensorIndex = 13579 }
            );

            // Optional: Configure table names if you want to change them
            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // Configure SimulationConfig with initial data
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
        
    }
    }
}