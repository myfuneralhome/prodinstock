using BTech.Prodinstock.DependencyInjection;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain;
using BTech.Prodinstock.Products.Domain.UseCases;
using BTech.Prodinstock.Products.Domain.UseCases.Invoices;
using BTech.Prodinstock.Products.Domain.UseCases.OrderProducts;
using BTech.Prodinstock.WebApi;
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

builder.Services.AddInvoicePdfGeneration();

builder.Services.TryAddScoped<ICurrentUserProvider, FakeUserProvider>();

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
