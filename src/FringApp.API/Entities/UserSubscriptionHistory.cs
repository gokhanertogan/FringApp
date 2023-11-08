using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class UserSubscriptionHistory
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string SubscriptionTypeId { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime CreatedTime { get; set; }
}