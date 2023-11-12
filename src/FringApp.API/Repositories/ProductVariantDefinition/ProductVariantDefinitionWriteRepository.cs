using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductVariantDefinition;

public class ProductVariantDefinitionWriteRepository : WriteRepository<Entities.ProductVariantDefinition>, IProductVariantDefinitionWriteRepository
{
    public ProductVariantDefinitionWriteRepository(FringDbContext context) : base(context)
    {
    }
}
