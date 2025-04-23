namespace AirQualityDashboard.Models
{
    
    public class SystemConfig
    {
        public int Id { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
