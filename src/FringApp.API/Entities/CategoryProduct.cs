namespace FringApp.API.Entities;
public class CategoryProduct : BaseEntity
{
    public string CategoryDefinitionId { get; set; } = null!;
    public ICollection<string> ProductIds { get; set; } = null!;
    public bool IsActive { get; set; }
}