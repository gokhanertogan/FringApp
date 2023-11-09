using FringApp.API.Entities;

namespace FringApp.API.Services;

public interface ISubscriptionService
{
    Task<SubscriptionDefinition> GetCurrentSubscription(string userId);
    Task<List<UserSubscriptionHistory>> GetUserSubscriptionHistories(string userId);
}