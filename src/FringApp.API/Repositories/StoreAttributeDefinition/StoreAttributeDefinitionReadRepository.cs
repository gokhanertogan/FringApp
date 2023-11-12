using FringApp.API.Data;

namespace FringApp.API.Repositories.StoreAttributeDefinition;

public class StoreAttributeDefinitionReadRepository : ReadRepository<Entities.StoreAttributeDefinition>, IStoreAttributeDefinitionReadRepository
{
    public StoreAttributeDefinitionReadRepository(FringDbContext context) : base(context)
    {
    }
}
