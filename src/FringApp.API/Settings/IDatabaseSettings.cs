namespace FringApp.API.Settings;

public interface IDatabaseSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    CollectionNameSettings CollectionNames { get; set; }
}