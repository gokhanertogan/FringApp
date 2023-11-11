namespace FringApp.API.Entities;
public class StoreAttribute : BaseEntity
{
    public StoreAttributeDefinition StoreAttributeDefinition { get; set; } = null!;
    public Store Store { get; set; } = null!;
}