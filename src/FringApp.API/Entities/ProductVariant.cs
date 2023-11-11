namespace FringApp.API.Entities;
public class ProductVariant : BaseEntity
{    public Product Product { get; set; } = null!;
    public ProductTemperatureDefinition ProductTemperatureDefinition { get; set; } = null!;
    public ProductVariantDefinition ProductVariantDefinition { get; set; } = null!;
    public ProductSizeDefinition ProductSizeDefinition { get; set; } = null!;
    public decimal Price { get; set; }
}