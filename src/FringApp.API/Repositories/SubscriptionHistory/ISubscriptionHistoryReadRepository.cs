namespace FringApp.API.Repositories.SubscriptionHistory;

public interface ISubscriptionHistoryReadRepository : IReadRepository<Entities.SubscriptionHistory>
{
    Task<List<Entities.SubscriptionHistory>> GetUserSubscriptionHistories(string userId);
}