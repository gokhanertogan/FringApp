using FringApp.API.Entities;
using FringApp.API.Repositories.Subscription;
using FringApp.API.Repositories.SubscriptionHistory;
using FringApp.API.Repositories.User;

namespace FringApp.API.Services.Subscription;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionReadRepository _subscriptionReadRepository;
    private readonly ISubscriptionWriteRepository _subscriptionWriteRepository;
    private readonly ISubscriptionHistoryReadRepository _subscriptionHistoryReadRepository;
    private readonly IUserReadRepository _userReadRepository;

    public SubscriptionService(ISubscriptionReadRepository subscriptionReadRepository, ISubscriptionWriteRepository subscriptionWriteRepository, IUserReadRepository userReadRepository, ISubscriptionHistoryReadRepository subscriptionHistoryReadRepository)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
        _subscriptionWriteRepository = subscriptionWriteRepository;
        _userReadRepository = userReadRepository;
        _subscriptionHistoryReadRepository = subscriptionHistoryReadRepository;
    }


    public async Task<SubscriptionDefinition> GetCurrentSubscription(string userId)
    {
        var user = await _userReadRepository.GetByIdAsync(userId);
        if (user is null)
            return new SubscriptionDefinition();

        return await _subscriptionReadRepository.GetUserCurrentSubscription(userId);
    }

    public async Task<List<SubscriptionHistory>> GetUserSubscriptionHistories(string userId)
    {
        var user = await _userReadRepository.GetByIdAsync(userId);
        if (user is null)
            return new List<SubscriptionHistory>();

        return await _subscriptionHistoryReadRepository.GetUserSubscriptionHistories(userId);
    }
}
