using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductSizeDefinition;

public class ProductSizeDefinitionWriteRepository : WriteRepository<Entities.ProductSizeDefinition>, IProductSizeDefinitionWriteRepository
{
    public ProductSizeDefinitionWriteRepository(FringDbContext context) : base(context)
    {
    }
}
