using FringApp.API.Data;

namespace FringApp.API.Repositories.CategoryDefinition;

public class CategoryDefinitionWriteRepository : WriteRepository<Entities.CategoryDefinition>, ICategoryDefinitionWriteRepository
{
    public CategoryDefinitionWriteRepository(FringDbContext context) : base(context)
    {
    }
}
