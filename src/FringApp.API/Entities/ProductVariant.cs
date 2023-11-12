namespace FringApp.API.Entities;
public class ProductVariant : BaseEntity
{
    public string ProductId { get; set; } = null!;
    public string ProductTemperatureDefinitionId { get; set; } = null!;
    public string ProductVariantDefinitionId { get; set; } = null!;
    public string ProductSizeDefinitionId { get; set; } = null!;
    public decimal Price { get; set; }
}