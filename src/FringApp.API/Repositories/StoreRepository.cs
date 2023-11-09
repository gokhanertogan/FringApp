using FringApp.API.Data;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly IFringDbContext _context;

    public StoreRepository(IFringDbContext context)
    {
        _context = context;
    }
    public async Task<Store> GetStore(string Id)
    {
        return await _context.Stores.Find(p => p.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<List<Store>> GetStores()
    {
        return await _context.Stores.Find(p => true).ToListAsync();
    }
}