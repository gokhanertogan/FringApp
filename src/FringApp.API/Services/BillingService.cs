using FringApp.API.Entities;
using FringApp.API.Repositories;

namespace FringApp.API.Services;

public class BillingService : IBillingService
{
    private readonly IUserRepository _userRepository;
    private readonly IBillingRepository _billingRepository;

    public BillingService(IBillingRepository billingRepository, IUserRepository userRepository)
    {
        _billingRepository = billingRepository;
        _userRepository = userRepository;
    }

    public async Task<Billing> GetUserBillingInformation(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return new Billing();

        return await _billingRepository.GetUserBillingInformation(userId);
    }
}
