using FringApp.API.Entities;

namespace FringApp.API.Repositories.Subscription;

public interface ISubscriptionReadRepository : IReadRepository<Entities.SubscriptionDefinition>
{
    Task<SubscriptionDefinition> GetUserCurrentSubscription(string Id);
}