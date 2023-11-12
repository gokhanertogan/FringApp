using FringApp.API.Data;
using MongoDB.Driver;

namespace FringApp.API.Repositories.Store;

public class StoreReadRepository : ReadRepository<Entities.Store>, IStoreReadRepository
{
    public StoreReadRepository(FringDbContext context) : base(context)
    {
    }

    public async Task<Entities.Store> GetStore(string Id)
    {
        return await Collection.Find(p => p.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<List<Entities.Store>> GetStores()
    {
        return await Collection.Find(p => true).ToListAsync();
    }
}
