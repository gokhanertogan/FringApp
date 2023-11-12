namespace FringApp.API.Repositories.Store;

public interface IStoreReadRepository : IReadRepository<Entities.Store>
{
    Task<List<Entities.Store>> GetStores();
    Task<Entities.Store> GetStore(string Id);
}