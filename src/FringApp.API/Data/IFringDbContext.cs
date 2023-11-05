using FringApp.API.Entites;
using MongoDB.Driver;

namespace FringApp.API.Data;

public interface IFringDbContext
{
    IMongoCollection<Order> Orders { get; }
    IMongoCollection<User> Users { get; }
    IMongoCollection<Product> Products { get; }
    IMongoCollection<Store> Stores { get; }
    IMongoCollection<Billing> Billingies { get; }
}