namespace TestPL.Models
{
    public class PollingSystemDatabaseSettings : IPollingSystemDatabaseSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        public string PollingSystemCollectionName { get; set; } = String.Empty;
    }
}
