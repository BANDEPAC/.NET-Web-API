using DAL.models;
using DAL.repositories;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigurationExtensions
{
    public static void ConfigureDAL(this IServiceCollection services, string connection)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection));

        // Настройка репозиториев
        services.AddTransient<IRepository<Product>, ProductRepository>();
        services.AddTransient<IRepository<Order>, OrderRepository>();
        services.AddTransient<IRepository<Category>, CategoryRepository>();
    }
}