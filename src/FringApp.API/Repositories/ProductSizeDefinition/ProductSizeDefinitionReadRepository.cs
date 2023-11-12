using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductSizeDefinition;

public class ProductSizeDefinitionReadRepository : ReadRepository<Entities.ProductSizeDefinition>, IProductSizeDefinitionReadRepository
{
    public ProductSizeDefinitionReadRepository(FringDbContext context) : base(context)
    {
    }
}
