namespace FringApp.API.Entities;
public class UserSubscriptionHistory : BaseEntity
{
    public User User { get; set; } = null!;
    public SubscriptionDefinition SubscriptionDefinition { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime CreatedTime { get; set; }
}