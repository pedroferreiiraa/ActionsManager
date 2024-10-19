using _5W2H.Core.Repositories;
using _5W2H.Core.Services;
using _5W2H.Infrastructure.AuthServices;
using _5W2H.Infrastructure.Persistence;
using _5W2H.Infrastructure.Repositories;
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
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<WhoDbContext>(o => o.UseSqlServer(connectionString));
        return services;
        
    }

    
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IActionRepository, ActionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IAuthService, AuthService>();

    

        return services;

    }

    
}