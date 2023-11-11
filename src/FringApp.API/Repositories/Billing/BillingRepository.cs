using FringApp.API.Data;
using MongoDB.Driver;

namespace FringApp.API.Repositories.Billing;

public class BillingRepository : IBillingRepository
{
    private readonly IFringDbContext _context;
    public BillingRepository(IFringDbContext context)
    {
        _context = context;
    }
    public async Task<Entities.Billing> GetUserBillingInformation(string userId)
    {
        return await _context.Billings.Find(p => p.User.Id == userId).FirstOrDefaultAsync();
    }
}
