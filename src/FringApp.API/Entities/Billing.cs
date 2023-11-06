using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class Billing
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}