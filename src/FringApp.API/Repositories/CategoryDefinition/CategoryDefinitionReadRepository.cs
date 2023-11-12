using FringApp.API.Data;

namespace FringApp.API.Repositories.CategoryDefinition;

public class CategoryDefinitionReadRepository : ReadRepository<Entities.CategoryDefinition>, ICategoryDefinitionReadRepository
{
    public CategoryDefinitionReadRepository(FringDbContext context) : base(context)
    {
    }
}
