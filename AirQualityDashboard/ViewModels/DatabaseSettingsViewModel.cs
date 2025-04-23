namespace AirQualityDashboard.ViewModels
{
    public class DatabaseSettingsViewModel
    {
        public string ConnectionString { get; set; }
        public string DatabaseProvider { get; set; }
        public List<string> Migrations { get; set; } = new List<string>();
    }
}
