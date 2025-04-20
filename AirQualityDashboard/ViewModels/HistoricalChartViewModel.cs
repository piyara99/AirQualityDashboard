using System;
using System.Collections.Generic;

namespace AirQualityDashboard.ViewModels
{
    public class HistoricalChartViewModel
    {
        public int SensorId { get; set; }
        public string SensorLocation { get; set; }

        public List<DateTime> Timestamps { get; set; }
        public List<double> AQIValues { get; set; }

        public string TimeRange { get; set; }
    }
}
