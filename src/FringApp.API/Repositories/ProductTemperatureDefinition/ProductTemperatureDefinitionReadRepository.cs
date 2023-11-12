using FringApp.API.Data;

namespace FringApp.API.Repositories.ProductTemperatureDefinition;

public class ProductTemperatureDefinitionReadRepository : ReadRepository<Entities.ProductTemperatureDefinition>, IProductTemperatureDefinitionReadRepository
{
    public ProductTemperatureDefinitionReadRepository(FringDbContext context) : base(context)
    {
    }
}
