using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductVariant;

public class ProductVariantReadRepository : ReadRepository<Entities.ProductVariant>, IProductVariantReadRepository
{
    public ProductVariantReadRepository(FringDbContext context) : base(context)
    {
    }
}
