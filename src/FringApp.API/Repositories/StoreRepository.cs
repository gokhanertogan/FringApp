using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public class StoreRepository : IStoreRepository
{
    public Task<Store> GetStore(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Store>> GetStores()
    {
        throw new NotImplementedException();
    }
}