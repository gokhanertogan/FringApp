using FringApp.API.Data;

namespace FringApp.API.Repositories.Order;

public class OrderWriteRepository : WriteRepository<Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(FringDbContext context) : base(context)
    {
    }
}
