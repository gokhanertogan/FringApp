using FringApp.API.Models.Requests;

namespace FringApp.API.Services.User;

public interface IUserService
{
    Task<Entities.User> Get(string userId);
    Task<Entities.User> Create(CreateUserRequestModel requestModel);
    Task<Entities.User> UnSubscribe(string userId);
    Task<bool> Delete(string userId);
}