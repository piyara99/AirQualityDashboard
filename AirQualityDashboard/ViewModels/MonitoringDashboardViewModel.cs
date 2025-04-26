using System;
using System.Collections.Generic;

namespace AirQualityDashboard.ViewModels
{
    public class MonitoringDashboardViewModel
    {
        public int TotalSensors { get; set; }
        public int ActiveSensors { get; set; }
        public int InactiveSensors => TotalSensors - ActiveSensors;

        public double AverageAirQualityIndex { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public int HealthySensors { get; set; }
        public int WarningSensors { get; set; }
        public int CriticalSensors { get; set; }

        public List<Sensor> TopSensors { get; set; } = new List<Sensor>();
        public Dictionary<string, int> SensorTypeCounts { get; set; } = new Dictionary<string, int>();
        public List<DateTime> Last7Days { get; set; } = new List<DateTime>();
        public List<int> DailySensorUpdates { get; set; } = new List<int>();

        public bool SimulationRunning { get; set; }

        public class Sensor
        {
            public string Name { get; set; }
            public double AirQualityIndex { get; set; }
            public bool IsActive { get; set; }
            public string Type { get; set; }
            public DateTime LastUpdated { get; set; }
        }
    }
}
