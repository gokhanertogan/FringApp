using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public interface IUserRepository
{
    Task<User> Get(string userId);
    Task<User> Create(User user);
    Task<bool> UnSubscribe(string userId);
    Task<bool> Delete(string userId);
}