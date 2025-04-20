using Microsoft.EntityFrameworkCore;

namespace AirQualityDashboard.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<AlertThreshold> AlertThresholds { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
