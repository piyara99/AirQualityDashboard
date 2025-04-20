using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQualityDashboard.Models
{
    public class SensorData
    {
        public int Id { get; set; }

        [Required]
        public int SensorId { get; set; }

        [ForeignKey("SensorId")]
        public Sensor Sensor { get; set; }

        [Required]
        public int AQI { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
