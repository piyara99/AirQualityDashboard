using System;
using System.Collections.Generic;

namespace AirQualityDashboard.ViewModels
{
    public class HistoricalChartViewModel
    {
        public int SensorId { get; set; }

        public string SensorLocation { get; set; } = string.Empty;

        public List<DateTime> Timestamps { get; set; } = new List<DateTime>();

        public List<double> AQIValues { get; set; } = new List<double>();

        public string TimeRange { get; set; } = string.Empty;
    }
}
