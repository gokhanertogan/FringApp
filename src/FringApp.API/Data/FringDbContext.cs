using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Data;

public class FringDbContext : IFringDbContext
{
    private readonly IMongoDatabase Database;
    public FringDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        Database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Orders = Database.GetCollection<Order>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Order"));
        StoreAttributes = Database.GetCollection<StoreAttribute>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:StoreAttribute"));
        Stores = Database.GetCollection<Store>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Store"));
        StoreAttributeDefinitions = Database.GetCollection<StoreAttributeDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:StoreAttributeDefinition"));
        Billings = Database.GetCollection<Billing>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Billing"));
        Users = Database.GetCollection<User>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:User"));
        Subscriptions = Database.GetCollection<SubscriptionDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Subscription"));
        SubscriptionHistories = Database.GetCollection<SubscriptionHistory>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:SubscriptionHistory"));
        Products = Database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Product"));
        Categories = Database.GetCollection<CategoryDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:CategoryDefinition"));
        CategoryProducts = Database.GetCollection<CategoryProduct>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:CategoryProduct"));
        ProductSizes = Database.GetCollection<ProductSizeDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductSize"));
        ProductTemperatures = Database.GetCollection<ProductTemperatureDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductTemperature"));
        ProductVariants = Database.GetCollection<ProductVariant>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductVariant"));
        ProductVariantDefinitions = Database.GetCollection<ProductVariantDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductVariantDefinition"));

        FringDbContextSeed.CategoryProductSeedData(CategoryProducts, Categories, Products, ProductSizes, ProductTemperatures, ProductVariantDefinitions, ProductVariants);
        FringDbContextSeed.StoreSeedData(Stores, StoreAttributes, StoreAttributeDefinitions);
    }
    public IMongoCollection<Order> Orders { get; }
    public IMongoCollection<User> Users { get; }
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<Store> Stores { get; }
    public IMongoCollection<Billing> Billings { get; }
    public IMongoCollection<CategoryDefinition> Categories { get; }
    public IMongoCollection<CategoryProduct> CategoryProducts { get; }
    public IMongoCollection<ProductSizeDefinition> ProductSizes { get; }
    public IMongoCollection<ProductTemperatureDefinition> ProductTemperatures { get; }
    public IMongoCollection<ProductVariant> ProductVariants { get; }
    public IMongoCollection<ProductVariantDefinition> ProductVariantDefinitions { get; }
    public IMongoCollection<StoreAttribute> StoreAttributes { get; }
    public IMongoCollection<StoreAttributeDefinition> StoreAttributeDefinitions { get; }
    public IMongoCollection<SubscriptionDefinition> Subscriptions { get; }
    public IMongoCollection<SubscriptionHistory> SubscriptionHistories { get; }

    public IMongoCollection<T> DbSet<T>()
    {
        var tableAttribute = typeof(T).GetCustomAttribute<TableAttribute>(false);
        var name = tableAttribute is null ? typeof(T).Name : tableAttribute!.Name;
        return Database.GetCollection<T>(name);
    }
}
