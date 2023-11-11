using FringApp.API.Data;
using FringApp.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FringApp.API.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private FringDbContext _context;
    public IMongoCollection<T> Collection { get; }
    public WriteRepository(FringDbContext context)
    {
        _context = context;
        Collection = _context.DbSet<T>();
    }
    public async Task<T> AddAsync(T model)
    {
        await Collection.InsertOneAsync(model);
        return model;
    }
    public async Task<List<T>> AddRangeAsync(List<T> datas)
    {
        await Collection.InsertManyAsync(datas);
        return datas;
    }
    public async Task<bool> Remove(object id)
    {
        if (!ObjectId.TryParse(id.ToString(), out ObjectId objectId))
        {
            return false;
        }
        var filterId = Builders<T>.Filter.Eq("_id", objectId);
        var deleted = await Collection.FindOneAndDeleteAsync(filterId);
        return deleted != null;
    }
    public bool Update(T model)
    {
        var filterId = Builders<T>.Filter.Eq("_id", model.Id);
        var updated = Collection.FindOneAndReplace(filterId, model);
        return updated != null;
    }
}