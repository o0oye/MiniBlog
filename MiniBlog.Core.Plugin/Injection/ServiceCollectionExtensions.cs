using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniBlog.Data;

namespace MiniBlog.Core.Plugin.Injection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMiniBlogMySqlDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MiniBlogDbContext>(options => options.UseMySql(connection));
            return services;
        }
    }
}
