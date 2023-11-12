using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T model);
    Task<List<T>> AddRangeAsync(List<T> datas);
    Task<bool> RemoveAsync(object id);
    // bool RemoveRange(List<T> datas);
    // Task<bool> RemoveAsync(string id);
    bool Update(T model);
}