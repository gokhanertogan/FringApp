using FringApp.API.Data;

namespace FringApp.API.Repositories.Billing;

public class BillingWriteRepository : WriteRepository<Entities.Billing>, IBillingWriteRepository
{
    public BillingWriteRepository(FringDbContext context) : base(context)
    {
    }
}
