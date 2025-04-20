namespace AirQualityDashboard.Models
{
    public class SimulationConfig
    {
        public int Id { get; set; }
        public int FrequencyInSeconds { get; set; } = 300;
        public int BaseAQI { get; set; } = 50;
        public int VariationRange { get; set; } = 20;
        public bool IsRunning { get; set; }
    }


}
