using FringApp.API.Entities;
using MongoDB.Driver;

namespace FringApp.API.Data;

public class FringDbContextSeed
{
    private static async Task<ProductVariantDefinition> ProductVariantDefinitionSeedData(IMongoCollection<ProductVariantDefinition> productVariantDefinitions, ProductVariantDefinition productVariantDefinition)
    {
        await productVariantDefinitions.InsertOneAsync(productVariantDefinition);
        return productVariantDefinition;
    }
    private static async Task<ProductTemperatureDefinition> ProductTemperatureDefinitionSeedData(IMongoCollection<ProductTemperatureDefinition> productTemperatures, ProductTemperatureDefinition productTemperatureDefinition)
    {
        await productTemperatures.InsertOneAsync(productTemperatureDefinition);
        return productTemperatureDefinition;
    }
    private static async Task<ProductSizeDefinition> ProductSizeDefinitionSeedData(IMongoCollection<ProductSizeDefinition> productSizes, ProductSizeDefinition productSizeDefinition)
    {
        await productSizes.InsertOneAsync(productSizeDefinition);
        return productSizeDefinition;
    }
    private static async Task<CategoryDefinition> CategoryDefinitionSeedData(IMongoCollection<CategoryDefinition> categoryDefinitions, CategoryDefinition categoryDefinition)
    {
        await categoryDefinitions.InsertOneAsync(categoryDefinition);
        return categoryDefinition;
    }
    public static async void CategoryProductSeedData(IMongoCollection<CategoryProduct> categoryProducts, IMongoCollection<CategoryDefinition> categoryDefinition, IMongoCollection<Product> products, IMongoCollection<ProductSizeDefinition> productSizes, IMongoCollection<ProductTemperatureDefinition> productTemperatures, IMongoCollection<ProductVariantDefinition> productVariantDefinitions, IMongoCollection<ProductVariant> productVariants)
    {
        var isExist = categoryProducts.Find(p => true).Any();

        if (!isExist)
        {
            var categoryData = new CategoryDefinition()
            {
                Name = "Hots",
                ParentId = null,
                IsActive = true
            };

            await CategoryDefinitionSeedData(categoryDefinition, categoryData);

            var productData = new Product
            {
                Name = "Misto",
                IsActive = true
            };

            await products.InsertOneAsync(productData);

            var productTemperatureDefinitionData = new ProductTemperatureDefinition()
            {
                Name = "Hots",
                IsActive = true
            };

            await ProductTemperatureDefinitionSeedData(productTemperatures, productTemperatureDefinitionData);

            var productVariantDefinitionDatas = new List<ProductVariantDefinition>
            {
                new()
                {
                    Name = "Laktoksuz"
                },
                new()
                {
                    Name = "Sütlü"
                },
                new()
                {
                    Name = "Sütsüz"
                }
            };

            var productSizeDefinitionDatas = new List<ProductSizeDefinition>
            {
                new()
                {
                    Name = "Small",
                    IsActive = true
                },
                new()
                {
                    Name = "Medium",
                    IsActive = true
                },
                new()
                {
                    Name = "Large",
                    IsActive = true
                }
            };

            foreach (var variantDefinitionData in productVariantDefinitionDatas)
            {
                await ProductVariantDefinitionSeedData(productVariantDefinitions, variantDefinitionData);

                foreach (var productSizeDefinitionData in productSizeDefinitionDatas)
                {
                    if (string.IsNullOrEmpty(productSizeDefinitionData.Id))
                        await ProductSizeDefinitionSeedData(productSizes, productSizeDefinitionData);

                    var productVariantData = new ProductVariant()
                    {
                        ProductId = productData.Id,
                        ProductTemperatureDefinitionId = productTemperatureDefinitionData.Id,
                        ProductVariantDefinitionId = variantDefinitionData.Id,
                        ProductSizeDefinitionId = productSizeDefinitionData.Id,
                        Price = 60
                    };

                    await productVariants.InsertOneAsync(productVariantData);
                }
            }

            productTemperatureDefinitionData = new ProductTemperatureDefinition()
            {
                Name = "Colds",
                IsActive = true
            };

            await ProductTemperatureDefinitionSeedData(productTemperatures, productTemperatureDefinitionData);
            var productDatas = new List<Product> { productData };

            foreach (var variantDefinitionData in productVariantDefinitionDatas)
            {
                if (string.IsNullOrEmpty(variantDefinitionData.Id))
                    await ProductVariantDefinitionSeedData(productVariantDefinitions, variantDefinitionData);

                foreach (var productSizeDefinitionData in productSizeDefinitionDatas)
                {
                    if (string.IsNullOrEmpty(productSizeDefinitionData.Id))
                        await ProductSizeDefinitionSeedData(productSizes, productSizeDefinitionData);

                    var productVariantData = new ProductVariant()
                    {
                        ProductId = productData.Id,
                        ProductTemperatureDefinitionId = productTemperatureDefinitionData.Id,
                        ProductVariantDefinitionId = variantDefinitionData.Id,
                        ProductSizeDefinitionId = productSizeDefinitionData.Id,
                        Price = 60
                    };

                    await productVariants.InsertOneAsync(productVariantData);
                }
            }

            var categoryProduct = new CategoryProduct()
            {
                CategoryDefinitionId = categoryData.Id,
                ProductIds = productDatas.Select(x => x.Id).ToList()
            };

            await categoryProducts.InsertOneAsync(categoryProduct);

            categoryData = new CategoryDefinition()
            {
                Name = "Colds",
                ParentId = null,
                IsActive = true
            };

            await categoryDefinition.InsertOneAsync(categoryData);

            productData = new Product
            {
                Name = "Cold Brew",
                IsActive = true
            };

            await products.InsertOneAsync(productData);
            productDatas.Clear();
            productDatas.Add(productData);

            categoryProduct = new CategoryProduct()
            {
                CategoryDefinitionId = categoryData.Id,
                ProductIds = productDatas.Select(x => x.Id).ToList()
            };

            await categoryProducts.InsertOneAsync(categoryProduct);
        }

    }
    public static async void StoreSeedData(IMongoCollection<Store> stores, IMongoCollection<StoreAttribute> storeAttributes, IMongoCollection<StoreAttributeDefinition> storeAttributeDefinitions)
    {
        var isExist = stores.Find(p => true).Any();

        if (!isExist)
        {
            List<StoreAttributeDefinition> storeAttributeDefinitions1 = new List<StoreAttributeDefinition>
                                                                        {
                                                                            new()
                                                                            {
                                                                                Name= "Wifi"
                                                                            },
                                                                            new()
                                                                            {
                                                                                Name= "Terrace"
                                                                            },
                                                                            new()
                                                                            {
                                                                                Name= "Car Park"
                                                                            }
                                                                        };
            var storeAttributeDefinitionDatas = storeAttributeDefinitions1;

            var storeDatas = new List<Store>
            {
                new()
                {
                    Name= "4. Levent Metro",
                    Address = "Eski Büyükdere Caddesi 4.Levent Metro Istasyonu Kağıthane/Istanbul",
                    Latitude = "41.085644",
                    Longitude="29.006690",
                    WorkingEndTime = new DateTime(2023,01,01,23,00,00),
                    WorkingStartTime = new DateTime(2023,01,01,09,00,00),
                },
                new()
                {
                    Name= "Acıbadem",
                    Address = "Eski Büyükdere Caddesi 4.Levent Metro Istasyonu Kağıthane/Istanbul",
                    Latitude = "41.085644",
                    Longitude="29.006690",
                    WorkingEndTime = new DateTime(2023,01,01,23,00,00),
                    WorkingStartTime = new DateTime(2023,01,01,09,00,00),
                },
                new()
                {
                    Name= "Atlas",
                    Address = "Eski Büyükdere Caddesi 4.Levent Metro Istasyonu Kağıthane/Istanbul",
                    Latitude = "41.085644",
                    Longitude="29.006690",
                    WorkingEndTime = new DateTime(2023,01,01,22,00,00),
                    WorkingStartTime = new DateTime(2023,01,01,10,00,00),
                },
            };

            foreach (var store in storeDatas)
            {
                await stores.InsertOneAsync(store);
                foreach (var attributeDefinition in storeAttributeDefinitionDatas)
                {
                    if (string.IsNullOrEmpty(attributeDefinition.Id))
                        await storeAttributeDefinitions.InsertOneAsync(attributeDefinition);

                    await storeAttributes.InsertOneAsync(new StoreAttribute
                    {
                        StoreId = store.Id,
                        StoreAttributeDefinitionId = attributeDefinition.Id
                    });
                }
            }
        }
    }
}