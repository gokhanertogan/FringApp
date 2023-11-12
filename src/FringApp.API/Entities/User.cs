namespace FringApp.API.Entities;
public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CellPhone { get; set; } = null!;
    public int Gender { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? SubscriptionDefinitionId { get; set; }
    public bool IsSubscribed { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}