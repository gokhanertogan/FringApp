namespace FringApp.API.Entites;

public class User
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CellPhone { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }
}