using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public interface IStoreRepository
{
    Task<List<Store>> GetStores();
    Task<Store> GetStore(string Id);
    
}