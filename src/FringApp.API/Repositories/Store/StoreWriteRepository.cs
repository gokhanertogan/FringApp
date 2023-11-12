using FringApp.API.Data;

namespace FringApp.API.Repositories.Store;

public class StoreWriteRepository : WriteRepository<Entities.Store>, IStoreWriteRepository
{
    public StoreWriteRepository(FringDbContext context) : base(context)
    {
    }
}
