namespace FringApp.API.Services.Billing;
public interface IBillingService
{
    Task<Entities.Billing> GetUserBillingInformation(string userId);
}