using FringApp.API.Data;

namespace FringApp.API.Repositories.CategoryProduct;

public class CategoryProductWriteRepository : WriteRepository<Entities.CategoryProduct>, ICategoryProductWriteRepository
{
    public CategoryProductWriteRepository(FringDbContext context) : base(context)
    {
    }
}
