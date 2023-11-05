using FringApp.API.Data;
using FringApp.API.Entites;
using MongoDB.Driver;

namespace FringApp.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IFringDbContext _context;

    public UserRepository(IFringDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(User user)
    {
        await _context.Users.InsertOneAsync(user);
        return true;
    }

    public async Task<bool> Delete(string userId)
    {
        var filter = Builders<User>.Filter.Eq(p => p.Id, userId);
        var deleteResult = await _context.Users.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<Billing> GetBillingInformation(string userId)
    {
        return await _context.Billingies.Find(p => p.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task<User> Get(string userId)
    {
        var user = await _context.Users.Find(p => p.Id == userId).FirstOrDefaultAsync();
        return user;
    }

    public async Task<bool> UnSubscribe(string userId)
    {
        var user = await _context.Users.Find(p => p.Id == userId).FirstOrDefaultAsync();
        user.IsActive = false;

        var updateResult = await _context.Users.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}