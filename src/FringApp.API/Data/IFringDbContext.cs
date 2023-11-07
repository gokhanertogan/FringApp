using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Data;

public interface IFringDbContext
{
    IMongoCollection<Order> Orders { get; }
    IMongoCollection<User> Users { get; }
    IMongoCollection<Product> Products { get; }
    IMongoCollection<Store> Stores { get; }
    IMongoCollection<Billing> Billings { get; }
    public IMongoCollection<Package> Packages { get; }
    public IMongoCollection<UserPackageHistory> UserPackageHistories { get; }
}