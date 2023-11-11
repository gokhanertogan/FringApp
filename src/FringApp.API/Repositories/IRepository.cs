using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IMongoCollection<T> Collection { get; }
}