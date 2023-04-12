using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Login.IRepository;
using Login.Repository;

namespace Login.Helper
{
    public static class DependencyInjectionMiddlewareConfig
    {
        public static void AddDependencyInjectionMiddlewares(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<IUserServiceRepository, UserServiceRepository>();
        }
    }
}
