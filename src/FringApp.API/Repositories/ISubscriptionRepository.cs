using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public interface ISubscriptionRepository
{
    Task<SubscriptionDefinition> GetUserCurrentSubscription(string Id);
    Task<List<UserSubscriptionHistory>> GetUserSubscriptionHistories(string userId);
}