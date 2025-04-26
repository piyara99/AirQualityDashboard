public class SimulationSettingsViewModel
{
    public int FrequencyInSeconds { get; set; }
    public int BaseAQI { get; set; }
    public int VariationRange { get; set; }

    public int AlertModerate { get; set; }
    public int AlertUnhealthy { get; set; }
}
