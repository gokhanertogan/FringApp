using FringApp.API.Data;
namespace FringApp.API.Repositories.CategoryProduct;
public class CategoryProductReadRepository : ReadRepository<Entities.CategoryProduct>, ICategoryProductReadRepository
{
    public CategoryProductReadRepository(FringDbContext context) : base(context)
    {
    }
}