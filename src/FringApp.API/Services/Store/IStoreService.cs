using FringApp.API.Dtos;

namespace FringApp.API.Services.Store;

public interface IStoreService
{
    Task<List<Entities.Store>> GetStores();
    Task<List<Entities.Store>> GetFilteredStores(StoreFilterDTO storeFilterDTO);
    Task<Entities.Store> GetStore(string Id);
}