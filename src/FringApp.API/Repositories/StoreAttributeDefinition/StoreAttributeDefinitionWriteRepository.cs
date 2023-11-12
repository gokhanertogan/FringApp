using FringApp.API.Data;
namespace FringApp.API.Repositories.StoreAttributeDefinition;

public class StoreAttributeDefinitionWriteRepository : WriteRepository<Entities.StoreAttributeDefinition>, IStoreAttributeDefinitionWriteRepository
{
    public StoreAttributeDefinitionWriteRepository(FringDbContext context) : base(context)
    {
    }
}
