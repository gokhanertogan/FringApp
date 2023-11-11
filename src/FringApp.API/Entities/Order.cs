namespace FringApp.API.Entities;
public class Order : BaseEntity
{
    public Product Product { get; set; } = null!;
    public User User { get; set; } = null!;
    public Store Store { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}