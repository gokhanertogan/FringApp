using FringApp.API.Repositories.Billing;
using FringApp.API.Repositories.User;

namespace FringApp.API.Services.Billing;

public class BillingService : IBillingService
{
    private readonly IBillingReadRepository _billingReadRepository;
    private readonly IUserReadRepository _userReadRepository;

    public BillingService(IUserReadRepository userReadRepository, IBillingReadRepository billingReadRepository)
    {
        _userReadRepository = userReadRepository;
        _billingReadRepository = billingReadRepository;
    }

    public async Task<Entities.Billing> GetUserBillingInformation(string userId)
    {
        var user = await _userReadRepository.GetByIdAsync(userId);
        if (user is null)
            return new Entities.Billing();

        return await _billingReadRepository.GetUserBillingInformation(userId);
    }
}
