using FringApp.API.Entities;
using FringApp.API.Repositories;

namespace FringApp.API.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUserRepository _userRepository;
    public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _userRepository = userRepository;
    }
    public async Task<SubscriptionDefinition> GetCurrentSubscription(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return new SubscriptionDefinition();

        return await _subscriptionRepository.GetUserCurrentSubscription(userId);
    }

    public async Task<List<UserSubscriptionHistory>> GetUserSubscriptionHistories(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return new List<UserSubscriptionHistory>();

        return await _subscriptionRepository.GetUserSubscriptionHistories(userId);
    }
}
