using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Data;

public class FringDbContext : IFringDbContext
{
    public FringDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Product"));
        Orders = database.GetCollection<Order>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Order"));
        Users = database.GetCollection<User>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:User"));
        Stores = database.GetCollection<Store>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Store"));
        Billings = database.GetCollection<Billing>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Billing"));
    }
    public IMongoCollection<Order> Orders { get; }
    public IMongoCollection<User> Users { get; }
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<Store> Stores { get; }
    public IMongoCollection<Billing> Billings { get; }
}
