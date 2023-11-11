namespace FringApp.API.Repositories;

public interface IUserRepository
{
    Task<Entities.User> Get(string userId);
    Task<Entities.User> Create(Entities.User user);
    Task<bool> UnSubscribe(string userId);
    Task<bool> Delete(string userId);
}