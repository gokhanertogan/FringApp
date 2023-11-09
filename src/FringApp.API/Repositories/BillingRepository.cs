using FringApp.API.Data;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Repositories;

public class BillingRepository : IBillingRepository
{
    private readonly IFringDbContext _context;
    public BillingRepository(IFringDbContext context)
    {
        _context = context;
    }
    public async Task<Billing> GetUserBillingInformation(string userId)
    {
        return await _context.Billings.Find(p => p.UserId == userId).FirstOrDefaultAsync();
    }
}
