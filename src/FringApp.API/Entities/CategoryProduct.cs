namespace FringApp.API.Entities;
public class CategoryProduct : BaseEntity
{
    public CategoryDefinition Category { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
    public bool IsActive { get; set; }
}