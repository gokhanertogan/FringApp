using FringApp.API.Data;
using MongoDB.Driver;

namespace FringApp.API.Repositories.Store;

public class StoreRepository : IStoreRepository
{
    private readonly IFringDbContext _context;

    public StoreRepository(IFringDbContext context)
    {
        _context = context;
    }
    public async Task<Entities.Store> GetStore(string Id)
    {
        return await _context.Stores.Find(p => p.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<List<Entities.Store>> GetStores()
    {
        return await _context.Stores.Find(p => true).ToListAsync();
    }
}