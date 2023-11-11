using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Data;

public class FringDbContext : IFringDbContext
{
    private IMongoDatabase Database;
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
        UserSubscriptionHistories = Database.GetCollection<UserSubscriptionHistory>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:UserSubscriptionHistory"));
        Products = Database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:Product"));
        Categories = Database.GetCollection<CategoryDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:CategoryDefinition"));
        CategoryProducts = Database.GetCollection<CategoryProduct>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:CategoryProduct"));
        ProductSizes = Database.GetCollection<ProductSizeDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductSize"));
        ProductTemperatures = Database.GetCollection<ProductTemperatureDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductTemperature"));
        ProductVariants = Database.GetCollection<ProductVariant>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductVariant"));
        ProductVariantDefinitions = Database.GetCollection<ProductVariantDefinition>(configuration.GetValue<string>("DatabaseSettings:CollectionNames:ProductVariantDefinition"));

        // FringDbContextSeed.ProductVariantDefinitonSeedData(ProductVariantDefinitions);
        // FringDbContextSeed.ProductTemperatureDefinitionSeedData(ProductTemperatures);
        // FringDbContextSeed.ProductSizeDefinitionSeedData(ProductSizes);
        // FringDbContextSeed.CategoryDefinitionSeedData(Categories);
        // FringDbContextSeed.ProductSeedData(Products);
        // FringDbContextSeed.CategoryProductSeedData(CategoryProducts);

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

    public IMongoCollection<T> DbSet<T>()
    {
        var name = typeof(T).GetCustomAttribute<TableAttribute>(false).Name;
        return Database.GetCollection<T>(name);
    }
}
