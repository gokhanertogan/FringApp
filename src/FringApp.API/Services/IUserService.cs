using FringApp.API.Entities;
using FringApp.API.Models.Requests;

namespace FringApp.API.Services;

public interface IUserService
{
    Task<User> Get(string userId);
    Task<User> Create(CreateUserRequestModel requestModel);
    Task<User> UnSubscribe(string userId);
    Task<bool> Delete(string userId);
}