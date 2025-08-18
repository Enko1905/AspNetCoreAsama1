using Microsoft.EntityFrameworkCore;
using Repositories;

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
    }
}
