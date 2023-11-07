using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class UserPackageHistory
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string PackageId { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
}