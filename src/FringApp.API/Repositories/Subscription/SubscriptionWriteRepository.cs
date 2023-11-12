using FringApp.API.Data;

namespace FringApp.API.Repositories.Subscription;

public class SubscriptionWriteRepository : WriteRepository<Entities.SubscriptionDefinition>, ISubscriptionWriteRepository
{
    public SubscriptionWriteRepository(FringDbContext context) : base(context)
    {
    }
}
