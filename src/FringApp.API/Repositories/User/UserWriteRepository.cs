using FringApp.API.Data;
using MongoDB.Driver;

namespace FringApp.API.Repositories.User;

public class UserWriteRepository : WriteRepository<Entities.User>, IUserWriteRepository
{
    public UserWriteRepository(FringDbContext context) : base(context)
    {
    }

    public async Task<bool> UnSubscribe(string userId)
    {
        var user = await Collection.Find(p => p.Id == userId).FirstOrDefaultAsync();
        user.IsSubscribed = false;

        var updateResult = await Collection.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
