using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _5W2H.Infrastructure;

public class InfrastructureModule
{
    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DevFreelaCs");   
  


        // Check if the environment is development and use InMemoryDb
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            services.AddDbContext<YourDbContext>(options =>
            {
                options.UseInMemoryDatabase("DevFreelaDb");
            });
        }
        else
        {
            // Use SQL Server connection string in production or other environments
            services.AddDbContext<YourDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        return services;
    }

}