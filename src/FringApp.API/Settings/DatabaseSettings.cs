namespace FringApp.API.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public CollectionNameSettings CollectionNames { get; set; } = null!;
}

public class CollectionNameSettings
{
    public string Product { get; set; } = null!;
    public string Order { get; set; } = null!;
    public string User { get; set; } = null!;
}