using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Product"), builder =>
                {
                    builder.EnableRetryOnFailure();
                    builder.MigrationsHistoryTable("__EFMigrationsHistory", "product");
                }), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
builder.Services.AddRepositories();
builder.Services.TryAddScoped<ProductCreation>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
