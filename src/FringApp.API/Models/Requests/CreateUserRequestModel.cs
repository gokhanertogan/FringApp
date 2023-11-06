using FringApp.API.Enums;

namespace FringApp.API.Models.Requests;
public record CreateUserRequestModel(
    string Name,
    string LastName,
    string Email,
    string CellPhone,
    Gender Gender,
    string ImageUrl);
