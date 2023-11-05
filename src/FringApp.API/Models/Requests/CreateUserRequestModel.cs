namespace FringApp.API.Models.Requests;
public class CreateUserRequestModel
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CellPhone { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}