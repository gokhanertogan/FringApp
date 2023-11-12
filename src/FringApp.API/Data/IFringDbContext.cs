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
    IMongoCollection<CategoryDefinition> Categories { get; }
    IMongoCollection<CategoryProduct> CategoryProducts { get; }
    IMongoCollection<ProductSizeDefinition> ProductSizes { get; }
    IMongoCollection<ProductTemperatureDefinition> ProductTemperatures { get; }
    IMongoCollection<ProductVariant> ProductVariants { get; }
    IMongoCollection<ProductVariantDefinition> ProductVariantDefinitions { get; }
    IMongoCollection<StoreAttribute> StoreAttributes { get; }
    IMongoCollection<StoreAttributeDefinition> StoreAttributeDefinitions { get; }
    public IMongoCollection<SubscriptionDefinition> Subscriptions { get; }
    public IMongoCollection<SubscriptionHistory> SubscriptionHistories { get; }
}