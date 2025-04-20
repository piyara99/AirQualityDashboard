namespace AirQualityDashboard.ViewModels
{
    public class SensorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CurrentAQI { get; set; }
    }
}
