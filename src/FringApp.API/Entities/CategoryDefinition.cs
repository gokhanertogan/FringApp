namespace FringApp.API.Entities;
public class CategoryDefinition : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? ParentId { get; set; }
    public bool IsActive { get; set; }
}