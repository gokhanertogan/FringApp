namespace FringApp.API.Entities;
public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
}