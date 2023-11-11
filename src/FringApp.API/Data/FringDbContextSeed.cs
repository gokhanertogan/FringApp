using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Data;

public class FringDbContextSeed
{
    private static Dictionary<string, List<Product>> categoryProduct = new();
    public static async void ProductVariantDefinitonSeedData(IMongoCollection<ProductVariantDefinition> productVariantDefinitions)
    {
        await productVariantDefinitions.InsertManyAsync(new List<ProductVariantDefinition>
        {
            new()
            {
                Name = "Laktoksuz"
            },
            new()
            {
                Name = "Sütsüz"
            },
            new()
            {
                Name = "Sütlü"
            }
        });
    }
    public static async void ProductTemperatureDefinitionSeedData(IMongoCollection<ProductTemperatureDefinition> productTemperatures)
    {
        await productTemperatures.InsertManyAsync(new List<ProductTemperatureDefinition>
        {
            new()
            {
                Name="Hot",
                IsActive=true
            },
            new()
            {
                Name="Cold",
                IsActive=true
            }
        });
    }
    public static async void ProductSizeDefinitionSeedData(IMongoCollection<ProductSizeDefinition> productSizes)
    {
        await productSizes.InsertManyAsync(new List<ProductSizeDefinition>
        {
            new()
            {
                Name="Small",
                IsActive=true
            },
            new()
            {
                Name="Medium",
                IsActive=true
            },
            new()
            {
                Name="Large",
                IsActive=true
            }
        });
    }
    public static async void CategoryDefinitionSeedData(IMongoCollection<CategoryDefinition> categories, IMongoCollection<Product> products)
    {
        var categoryData = new List<CategoryDefinition>
        {
            new()
            {
                Name = "Hots",
                ParentId= null,
                IsActive=true
            },
            new()
            {
                Name = "Colds",
                ParentId= null,
                IsActive=true
            }
        };

        foreach (var category in categoryData)
        {
            await categories.InsertOneAsync(category);
            var productDatas = new List<Product>
            {
                new()
                {
                    Name="Misto",
                    IsActive=true
                }
            };

            ProductSeedData(products, productDatas);
            categoryProduct.Add(category.Id, productDatas);
        }
    }
    public static async void ProductSeedData(IMongoCollection<Product> products, List<Product> productDatas)
    {
        await products.InsertManyAsync(productDatas);
    }
    public static async void CategoryProductSeedData(IMongoCollection<CategoryProduct> categoryProducts, IMongoCollection<CategoryDefinition> categoryDefiniton)
    {
        var categoryData = new List<CategoryDefinition>
        {
            new()
            {
                Name = "Hots",
                ParentId= null,
                IsActive=true
            }
        };

        await categoryDefiniton.InsertOneAsync(categoryData.Last());
        var productDatas = new List<Product>
                            {
                                new()
                                {
                                    Name="Misto",
                                    IsActive=true
                                }
                            };

        var categoryProduct = new CategoryProduct()
        {
            Category = categoryData.Last(),
            Products = productDatas
        };

        await categoryProducts.InsertOneAsync(categoryProduct);
    }
}