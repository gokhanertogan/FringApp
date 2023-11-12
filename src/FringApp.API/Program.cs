using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using FringApp.API.Data;
using FringApp.API.Repositories.Billing;
using FringApp.API.Repositories.CategoryDefinition;
using FringApp.API.Repositories.CategoryProduct;
using FringApp.API.Repositories.Order;
using FringApp.API.Repositories.Product;
using FringApp.API.Repositories.ProductSizeDefinition;
using FringApp.API.Repositories.ProductTemperatureDefinition;
using FringApp.API.Repositories.ProductVariant;
using FringApp.API.Repositories.ProductVariantDefinition;
using FringApp.API.Repositories.Store;
using FringApp.API.Repositories.StoreAttribute;
using FringApp.API.Repositories.StoreAttributeDefinition;
using FringApp.API.Repositories.Subscription;
using FringApp.API.Repositories.SubscriptionHistory;
using FringApp.API.Repositories.User;
using FringApp.API.Services.Billing;
using FringApp.API.Services.Subscription;
using FringApp.API.Services.User;
using FringApp.API.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddTransient<IFringDbContext, FringDbContext>();
builder.Services.AddSingleton<FringDbContext>();

builder.Services.AddTransient<IUserReadRepository, UserReadRepository>();
builder.Services.AddTransient<IUserWriteRepository, UserWriteRepository>();
builder.Services.AddTransient<ISubscriptionHistoryReadRepository, SubscriptionHistoryReadRepository>();
builder.Services.AddTransient<ISubscriptionHistoryWriteRepository, SubscriptionHistoryWriteRepository>();
builder.Services.AddTransient<ISubscriptionReadRepository, SubscriptionReadRepository>();
builder.Services.AddTransient<ISubscriptionWriteRepository, SubscriptionWriteRepository>();
builder.Services.AddTransient<IStoreAttributeDefinitionReadRepository, StoreAttributeDefinitionReadRepository>();
builder.Services.AddTransient<IStoreAttributeDefinitionWriteRepository, StoreAttributeDefinitionWriteRepository>();
builder.Services.AddTransient<IStoreAttributeReadRepository, StoreAttributeReadRepository>();
builder.Services.AddTransient<IStoreAttributeWriteRepository, StoreAttributeWriteRepository>();
builder.Services.AddTransient<IStoreReadRepository, StoreReadRepository>();
builder.Services.AddTransient<IStoreWriteRepository, StoreWriteRepository>();
builder.Services.AddTransient<IProductVariantDefinitionReadRepository, ProductVariantDefinitionReadRepository>();
builder.Services.AddTransient<IProductVariantDefinitionWriteRepository, ProductVariantDefinitionWriteRepository>();
builder.Services.AddTransient<IProductVariantReadRepository, ProductVariantReadRepository>();
builder.Services.AddTransient<IProductVariantWriteRepository, ProductVariantWriteRepository>();
builder.Services.AddTransient<IProductTemperatureDefinitionReadRepository, ProductTemperatureDefinitionReadRepository>();
builder.Services.AddTransient<IProductTemperatureDefinitionWriteRepository, ProductTemperatureDefinitionWriteRepository>();
builder.Services.AddTransient<IProductSizeDefinitionReadRepository, ProductSizeDefinitionReadRepository>();
builder.Services.AddTransient<IProductSizeDefinitionWriteRepository, ProductSizeDefinitionWriteRepository>();
builder.Services.AddTransient<IProductReadRepository, ProductReadRepository>();
builder.Services.AddTransient<IProductWriteRepository, ProductWriteRepository>();
builder.Services.AddTransient<IOrderReadRepository, OrderReadRepository>();
builder.Services.AddTransient<IOrderWriteRepository, OrderWriteRepository>();
builder.Services.AddTransient<ICategoryProductReadRepository, CategoryProductReadRepository>();
builder.Services.AddTransient<ICategoryProductWriteRepository, CategoryProductWriteRepository>();
builder.Services.AddTransient<ICategoryDefinitionReadRepository, CategoryDefinitionReadRepository>();
builder.Services.AddTransient<ICategoryDefinitionWriteRepository, CategoryDefinitionWriteRepository>();
builder.Services.AddTransient<IBillingReadRepository, BillingReadRepository>();
builder.Services.AddTransient<IBillingWriteRepository, BillingWriteRepository>();


builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISubscriptionService, SubscriptionService>();
builder.Services.AddTransient<IBillingService, BillingService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
