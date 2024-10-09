using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using _5W2H.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _5W2H.Infrastructure;

public static class InfrastructureModule 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);

        return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        // var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<WhoDbContext>(o => o.UseInMemoryDatabase("InMemoryDatabase"));
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IProjectRepository, ProjectRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;

    }
    
    
}