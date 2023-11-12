using FringApp.API.Data;
namespace FringApp.API.Repositories.ProductTemperatureDefinition;
public class ProductTemperatureDefinitionWriteRepository : WriteRepository<Entities.ProductTemperatureDefinition>, IProductTemperatureDefinitionWriteRepository
{
    public ProductTemperatureDefinitionWriteRepository(FringDbContext context) : base(context)
    {
    }
}
