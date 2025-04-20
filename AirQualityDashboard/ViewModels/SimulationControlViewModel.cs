using System.ComponentModel.DataAnnotations;

namespace AirQualityDashboard.ViewModels
{
    public class SimulationControlViewModel
    {
        [Display(Name = "Baseline AQI")]
        public int BaselineAQI { get; set; }

        [Display(Name = "Variation Range")]
        public int VariationRange { get; set; }

        [Display(Name = "Frequency (seconds)")]
        public int FrequencySeconds { get; set; }

        public bool IsRunning { get; set; }
    }
}
