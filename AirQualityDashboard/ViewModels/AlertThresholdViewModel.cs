using System.ComponentModel.DataAnnotations;

namespace AirQualityDashboard.ViewModels
{
    public class AlertThresholdViewModel
    {
        public int Id { get; set; }

        [Required]
        public string AQICategory { get; set; }

        [Required]
        [Display(Name = "Minimum AQI")]
        public int MinValue { get; set; }

        [Required]
        [Display(Name = "Maximum AQI")]
        public int MaxValue { get; set; }

        public string ColorCode { get; set; }
    }
}
