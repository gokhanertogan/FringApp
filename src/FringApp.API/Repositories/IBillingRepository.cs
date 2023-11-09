using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public interface IBillingRepository
{
    Task<Billing> GetUserBillingInformation(string userId);
}