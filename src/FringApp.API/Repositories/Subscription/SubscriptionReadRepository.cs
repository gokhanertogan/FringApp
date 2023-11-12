using FringApp.API.Data;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Repositories.Subscription;

public class SubscriptionReadRepository : ReadRepository<Entities.SubscriptionDefinition>, ISubscriptionReadRepository
{
    public SubscriptionReadRepository(FringDbContext context) : base(context)
    {
    }

    public async Task<SubscriptionDefinition> GetUserCurrentSubscription(string Id)
    {
        return await Collection.Find(p => p.Id == Id).FirstOrDefaultAsync();
    }
}
