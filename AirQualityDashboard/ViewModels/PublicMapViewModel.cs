using System.Collections.Generic;
using AirQualityDashboard.Models;

namespace AirQualityDashboard.ViewModels
{
    public class PublicMapViewModel
    {
        public List<Sensor> Sensors { get; set; }
        public List<SensorData> RecentData { get; set; }
        public Dictionary<int, double> CurrentAQIBySensorId { get; set; }
    }
}
