using AirQualityDashboard.Models;

namespace AirQualityDashboard.Models;
public class Sensor
{
    public int Id { get; set; }
   

    public  required string LocationName { get; set; }
    public required string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsActive { get; set; }
    public int SensorIndex { get; set; }

    public string? Type { get; set; }  // e.g., "Urban", "Industrial", etc.


    public ICollection<SensorData> SensorDataRecords { get; set; } = new List<SensorData>();

}
