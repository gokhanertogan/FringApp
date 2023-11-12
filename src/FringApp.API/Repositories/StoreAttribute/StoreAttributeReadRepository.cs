using FringApp.API.Data;
namespace FringApp.API.Repositories.StoreAttribute;

public class StoreAttributeReadRepository : ReadRepository<Entities.StoreAttribute>, IStoreAttributeReadRepository
{
    public StoreAttributeReadRepository(FringDbContext context) : base(context)
    {
    }
}
