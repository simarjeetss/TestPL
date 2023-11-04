namespace TestPL.Models
{
    public interface IPollingSystemDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string PollingSystemCollectionName { get; set; }
    }
}
