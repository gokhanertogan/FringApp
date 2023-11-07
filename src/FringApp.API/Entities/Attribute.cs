using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class Attribute
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}