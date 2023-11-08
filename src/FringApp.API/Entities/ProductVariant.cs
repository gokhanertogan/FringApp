using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class ProductVariant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public string ProductTemperatureDefinitionId { get; set; } = null!;
    public string ProductVariantDefinitionId { get; set; } = null!;
    public string ProductSizeDefinitionId { get; set; } = null!;
    public decimal Price { get; set; }
}