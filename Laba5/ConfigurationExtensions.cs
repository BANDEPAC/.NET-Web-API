using BLL;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public static class ConfigurationExtensions
{
    public static void ConfigureUI(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConnection");
        services.ConfigureBLL(connectionString);
       
    }
}

