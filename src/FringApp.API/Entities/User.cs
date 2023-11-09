using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FringApp.API.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CellPhone { get; set; } = null!;
    public int Gender { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool? CurrentSubscriptionId { get; set; }
    public bool IsSubscribed { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}