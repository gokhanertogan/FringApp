using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductVariantDefinition;

public class ProductVariantDefinitionReadRepository : ReadRepository<Entities.ProductVariantDefinition>, IProductVariantDefinitionReadRepository
{
    public ProductVariantDefinitionReadRepository(FringDbContext context) : base(context)
    {
    }
}
