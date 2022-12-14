using Prodinstock.DependencyInjection;
using Prodinstock.Infrastructure.Storage.Ef;
using Prodinstock.Products.Domain;
using Prodinstock.Products.Domain.UseCases;
using Prodinstock.Products.Domain.UseCases.Invoices;
using Prodinstock.Products.Domain.UseCases.OrderProducts;
using Prodinstock.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
    options.UseNpgsql(builder.Configuration.GetConnectionString("Product"), builder =>
    {
        builder.EnableRetryOnFailure();
        builder.MigrationsHistoryTable("__EFMigrationsHistory", "product");
    });
});
builder.Services.AddRepositories();
builder.Services.AddQueries();
builder.Services.TryAddScoped<ProductCreation>();
builder.Services.TryAddScoped<CategoryCreation>();
builder.Services.TryAddScoped<SupplierCreation>();
builder.Services.TryAddScoped<OrderProductCreation>();
builder.Services.TryAddScoped<InvoiceCreation>();
builder.Services.TryAddScoped<InvoiceValidation>();
builder.Services.TryAddScoped<InvoiceNumberGenerator>();
builder.Services.TryAddScoped<UserCompanyCreation>();

builder.Services.AddInvoicePdfGeneration();

builder.Services.AddUserProvider();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(app.Configuration.GetSection("CORS:AllowedOrigins").GetChildren().Select(v => v.Value).ToArray()));

app.MapControllers();

app.Run();
