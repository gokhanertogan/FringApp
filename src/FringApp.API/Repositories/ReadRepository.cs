using System.Linq.Expressions;
using FringApp.API.Data;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private FringDbContext _context;
    public IMongoCollection<T> Collection { get; }

    public ReadRepository(FringDbContext context)
    {
        _context = context;
        Collection = _context.DbSet<T>();
    }

    public IQueryable<T> GetAll()
    {
        return Collection.AsQueryable();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public T GetSingle(Expression<Func<T, bool>> condition)
    {
        return Collection.AsQueryable().Where(condition).FirstOrDefault()!;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> condition)
    {
        return Collection.AsQueryable().Where(condition).AsQueryable()!;
    }
}
