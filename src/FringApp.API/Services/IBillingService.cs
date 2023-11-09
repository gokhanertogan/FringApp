using FringApp.API.Entities;

namespace FringApp.API.Services;

public interface IBillingService
{
    Task<Billing> GetUserBillingInformation(string userId);
}