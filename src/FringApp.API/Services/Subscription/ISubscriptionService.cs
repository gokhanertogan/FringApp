using FringApp.API.Entities;

namespace FringApp.API.Services.Subscription;

public interface ISubscriptionService
{
    Task<SubscriptionDefinition> GetCurrentSubscription(string userId);
    Task<List<SubscriptionHistory>> GetUserSubscriptionHistories(string userId);
}