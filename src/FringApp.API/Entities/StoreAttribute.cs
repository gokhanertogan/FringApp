using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class StoreAttribute
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string StoreAttributeDefinitionId { get; set; } = null!;
    public string StoreId { get; set; } = null!;
}