using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contratcs;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlserverConnection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<RepositoryContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
            });
        }
        public static void ConfigureRepositoryManager(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
        public static void RegisterRepositories(this IServiceCollection services) { 
         services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void RegisterServices(this IServiceCollection services) { 
        services.AddScoped<IProductService,ProductManager>();
        }
    }
}
