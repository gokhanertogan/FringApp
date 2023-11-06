using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string StoreId { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}