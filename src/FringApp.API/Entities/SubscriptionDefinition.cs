namespace FringApp.API.Entities;
public class SubscriptionDefinition : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}