namespace FringApp.API.Entities;
public class SubscriptionHistory : BaseEntity
{
    public string UserId { get; set; } = null!;
    public string SubscriptionDefinitionId { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime CreatedTime { get; set; }
}