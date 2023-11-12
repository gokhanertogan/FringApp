using FringApp.API.Data;

namespace FringApp.API.Repositories.Product;

public class ProductWriteRepository : WriteRepository<Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(FringDbContext context) : base(context)
    {
    }
}
