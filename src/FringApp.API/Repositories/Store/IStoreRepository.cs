namespace FringApp.API.Repositories.Store;

public interface IStoreRepository
{
    Task<List<Entities.Store>> GetStores();
    Task<Entities.Store> GetStore(string Id);
}