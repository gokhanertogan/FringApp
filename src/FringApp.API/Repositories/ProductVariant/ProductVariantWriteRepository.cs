using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductVariant;

public class ProductVariantWriteRepository : WriteRepository<Entities.ProductVariant>, IProductVariantWriteRepository
{
    public ProductVariantWriteRepository(FringDbContext context) : base(context)
    {
    }
}
