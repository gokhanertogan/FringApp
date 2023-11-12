using FringApp.API.Data;

namespace FringApp.API.Repositories.StoreAttribute;
public class StoreAttributeWriteRepository : WriteRepository<Entities.StoreAttribute>, IStoreAttributeWriteRepository
{
    public StoreAttributeWriteRepository(FringDbContext context) : base(context)
    {
    }
}
