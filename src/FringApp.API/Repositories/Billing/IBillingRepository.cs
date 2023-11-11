namespace FringApp.API.Repositories;

public interface IBillingRepository
{
    Task<Entities.Billing> GetUserBillingInformation(string userId);
}