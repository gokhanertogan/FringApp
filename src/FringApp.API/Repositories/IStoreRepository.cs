using FringApp.API.Entites;

namespace FringApp.API.Repositories;

public interface IStoreRepository
{
    Task<List<Store>> GetStores();
    Task<Store> GetStore(string Id);
    
}