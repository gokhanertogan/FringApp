namespace FringApp.API.Entites;

public class Product
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ProductType { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}