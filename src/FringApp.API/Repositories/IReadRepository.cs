using System.Linq.Expressions;
using FringApp.API.Entities;

namespace FringApp.API.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
    T GetSingle(Expression<Func<T, bool>> method);
    Task<T> GetByIdAsync(string id);
}