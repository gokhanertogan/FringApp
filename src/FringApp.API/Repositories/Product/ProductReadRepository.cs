using FringApp.API.Data;

namespace FringApp.API.Repositories.Product;

public class ProductReadRepository : ReadRepository<Entities.Product>, IProductReadRepository
{
    public ProductReadRepository(FringDbContext context) : base(context)
    {
    }
}
