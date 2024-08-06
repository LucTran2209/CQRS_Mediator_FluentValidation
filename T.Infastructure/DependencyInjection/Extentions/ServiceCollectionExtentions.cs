using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using T.Infastructure.Common;

namespace T.Infastructure.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServiceInfastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            //services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
