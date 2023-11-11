namespace FringApp.API.Entities;
public class ProductSizeDefinition : BaseEntity
{
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
}