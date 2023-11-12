using FringApp.API.Data;

namespace FringApp.API.Repositories.Order;

public class OrderReadRepository : ReadRepository<Entities.Order>, IOrderReadRepository
{
    public OrderReadRepository(FringDbContext context) : base(context)
    {
    }
}
