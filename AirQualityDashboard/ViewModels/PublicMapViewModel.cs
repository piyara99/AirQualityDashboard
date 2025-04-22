using System.Collections.Generic;
using AirQualityDashboard.Models;

namespace AirQualityDashboard.ViewModels
{
    public class PublicMapViewModel
    {
        public List<Sensor> Sensors { get; set; } = new List<Sensor>();
        public List<SensorData> RecentData { get; set; } = new List<SensorData>();
        public Dictionary<int, double> CurrentAQIBySensorId { get; set; } = new Dictionary<int, double>();
    }
}
