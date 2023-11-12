namespace FringApp.API.Entities;
public class Order : BaseEntity
{
    public string ProductId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string StoreId { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}