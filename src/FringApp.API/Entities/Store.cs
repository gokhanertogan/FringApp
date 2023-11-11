namespace FringApp.API.Entities;
public class Store : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public DateTime WorkingStartTime { get; set; }
    public DateTime WorkingEndTime { get; set; }
}