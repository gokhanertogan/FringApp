using FringApp.API.Data;

namespace FringApp.API.Repositories.User;

public class UserReadRepository : ReadRepository<Entities.User>, IUserReadRepository
{
    public UserReadRepository(FringDbContext context) : base(context)
    {
    }
}
