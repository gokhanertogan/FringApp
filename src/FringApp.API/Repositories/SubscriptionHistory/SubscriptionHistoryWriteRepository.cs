using FringApp.API.Data;

namespace FringApp.API.Repositories.SubscriptionHistory;

public class SubscriptionHistoryWriteRepository : WriteRepository<Entities.SubscriptionHistory>, ISubscriptionHistoryWriteRepository
{
    public SubscriptionHistoryWriteRepository(FringDbContext context) : base(context)
    {
    }
}
