using System.ComponentModel.DataAnnotations;

namespace AirQualityDashboard.Models
{
    public class AlertThreshold
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }  // e.g., "Good", "Moderate", "Unhealthy"

        [Required]
        public int MinAQI { get; set; }

        [Required]
        public int MaxAQI { get; set; }

        [Required]
        public string ColorHex { get; set; } // e.g., "#00e400" (green for good)
    }
}
