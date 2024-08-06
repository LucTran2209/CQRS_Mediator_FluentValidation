
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace T.Persistence.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddSqlServerPersistence(this IServiceCollection services, string section)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(section));               
        }
      
    }
}
