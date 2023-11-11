namespace FringApp.API.Entities;
public class Billing : BaseEntity
{
    public User User { get; set; } = null!;
    public string Address { get; set; } = null!;
}