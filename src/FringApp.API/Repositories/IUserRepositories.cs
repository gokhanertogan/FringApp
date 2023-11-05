using FringApp.API.Entites;

namespace FringApp.API.Repositories;

public interface IUserRepository
{
    Task<User> Get(string userId);
    Task<bool> Create(User user);
    Task<bool> UnSubscribe(string userId);
    Task<bool> Delete(string userId);
    Task<Billing> GetBillingInformation(string userId);
}