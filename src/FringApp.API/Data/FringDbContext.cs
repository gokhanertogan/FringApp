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
        Subscriptions = database.GetCollection<SubscriptionDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Subscription"));
        UserSubscriptionHistories = database.GetCollection<UserSubscriptionHistory>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:UserSubscriptionHistory"));
        Categories = database.GetCollection<CategoryDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:CategoryDefinition"));
        CategoryProducts = database.GetCollection<CategoryProduct>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:CategoryProduct"));
        ProductSizes = database.GetCollection<ProductSizeDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductSize"));
        ProductTemperatures = database.GetCollection<ProductTemperatureDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductTemperature"));
        ProductVariants = database.GetCollection<ProductVariant>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductVariant"));
        ProductVariantDefinitions = database.GetCollection<ProductVariantDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductVariantDefinition"));
        StoreAttributes = database.GetCollection<StoreAttribute>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:StoreAttribute"));
        StoreAttributeDefinitions = database.GetCollection<StoreAttributeDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:StoreAttributeDefinition"));
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
    public IMongoCollection<UserSubscriptionHistory> UserSubscriptionHistories { get; }
}
