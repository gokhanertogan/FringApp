using FringApp.API.Data;
using MongoDB.Driver;

namespace FringApp.API.Repositories.Billing;

public class BillingReadRepository : ReadRepository<Entities.Billing>, IBillingReadRepository
{
    public BillingReadRepository(FringDbContext context) : base(context)
    {
    }

    public async Task<Entities.Billing> GetUserBillingInformation(string userId)
    {
        return await Collection.Find(p => p.UserId == userId).FirstOrDefaultAsync();
    }
}
