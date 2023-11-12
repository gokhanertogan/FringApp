namespace FringApp.API.Entities;
public class Billing : BaseEntity
{
    public string UserId { get; set; } = null!;
    public string Address { get; set; } = null!;
}