using FringApp.API.Data;
using MongoDB.Driver;

namespace FringApp.API.Repositories.SubscriptionHistory;

public class SubscriptionHistoryReadRepository : ReadRepository<Entities.SubscriptionHistory>, ISubscriptionHistoryReadRepository
{
    public SubscriptionHistoryReadRepository(FringDbContext context) : base(context)
    {
    }

    public async Task<List<Entities.SubscriptionHistory>> GetUserSubscriptionHistories(string userId)
    {
        return await Collection.Find(p => p.UserId == userId).ToListAsync();
    }
}
