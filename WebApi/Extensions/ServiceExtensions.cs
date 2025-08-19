using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "1.Aşama Api Projesi",
                    Version = "v1",
                    Description = "Rest Api",

                });
            });
        }
    }
}
