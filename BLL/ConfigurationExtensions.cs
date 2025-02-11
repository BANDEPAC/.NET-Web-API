using BLL.DTO;
using BLL.Interfaces;
using BLL.Profiles;
using BLL.Services;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureBLL(this IServiceCollection services,string connection)
        {
            services.ConfigureDAL(connection);
            services.AddAutoMapper(
                typeof(OrderProfile),
                typeof(ProductProfile),
                typeof(CategoryProfile)
                );
            services.AddTransient<ISearchByName<ProductDTO>, SearchProductByBothCases>();
            services.AddTransient<IService<ProductDTO>, SearchProductByBothCases>();
            services.AddTransient<ISearchByPrice<ProductDTO>, SearchProductByBothCases>();
            services.AddTransient<IService<OrderDTO>, OrderService>();
            services.AddTransient<IService<CategoryDTO>, CategoryService>();
            services.AddTransient<Ilaba5Service<ProductDTO>, laba5service>();

        }
    }
}

//System.InvalidOperationException: "Unable to resolve service for type 'DAL.IRepository`1[BLL.DTO.CategoryDTO]' while attempting to activate 'BLL.Services.CategoryService'."

