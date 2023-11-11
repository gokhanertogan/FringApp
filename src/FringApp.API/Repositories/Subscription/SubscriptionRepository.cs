using FringApp.API.Data;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Repositories.Subscription;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly IFringDbContext _context;

    public SubscriptionRepository(IFringDbContext context)
    {
        _context = context;
    }

    public async Task<SubscriptionDefinition> GetUserCurrentSubscription(string Id)
    {
        return await _context.Subscriptions.Find(p => p.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<List<UserSubscriptionHistory>> GetUserSubscriptionHistories(string userId)
    {
        return await _context.UserSubscriptionHistories.Find(p => p.User.Id == userId).ToListAsync();
    }
}
