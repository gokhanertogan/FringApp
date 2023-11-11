using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
}