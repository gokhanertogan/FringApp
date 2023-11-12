namespace FringApp.API.Repositories.Billing;

public interface IBillingReadRepository : IReadRepository<Entities.Billing>
{
    Task<Entities.Billing> GetUserBillingInformation(string userId);
}