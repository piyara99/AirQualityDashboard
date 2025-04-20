using AirQualityDashboard.Models;

namespace AirQualityDashboard.Models;
public class Sensor
{
    public int Id { get; set; }
   

    public string LocationName { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsActive { get; set; }
    public int SensorIndex { get; set; }

    public ICollection<SensorData> SensorDataRecords { get; set; } = new List<SensorData>();

}
