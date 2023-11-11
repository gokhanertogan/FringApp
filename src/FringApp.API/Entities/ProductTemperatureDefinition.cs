namespace FringApp.API.Entities;

public class ProductTemperatureDefinition : BaseEntity
{
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
}