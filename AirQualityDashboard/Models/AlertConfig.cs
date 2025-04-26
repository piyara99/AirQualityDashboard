namespace AirQualityDashboard.Models
{
    public class AlertConfig
    {
        public int Id { get; set; }
        public int ModerateThreshold { get; set; } = 100;
        public int UnhealthyThreshold { get; set; } = 150;
    }
}
