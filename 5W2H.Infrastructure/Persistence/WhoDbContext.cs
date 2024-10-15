
using _5W2H.Core;
using _5W2H.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Infrastructure.Persistence;

public class WhoDbContext : DbContext
{
    
    public class WhoDbContextFactory : IDesignTimeDbContextFactory<WhoDbContext>
    {
        public WhoDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<WhoDbContext>();
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            optionsBuilder.UseNpgsql(connectionString);

            return new WhoDbContext(optionsBuilder.Options);
        }
    }

    public WhoDbContext(DbContextOptions<WhoDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Action> Actions { get; set; } 
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configuração da entidade User
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);
            e.HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId);

            e.HasMany(u => u.Projects)
                .WithOne() // Um usuário pode ter muitos projetos
                .HasForeignKey(p => p.UserId); // Chave estrangeira para projetos

            e.HasMany(u => u.Actions)
                .WithOne(a => a.User) // Um usuário pode ter várias ações
                .HasForeignKey(a => a.UserId); // Chave estrangeira para ações
        });

        // Configuração da entidade Project
        builder.Entity<Project>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasMany(p => p.Actions)
                .WithOne(a => a.Project) // Um projeto pode ter várias ações
                .HasForeignKey(a => a.ProjectId); // Chave estrangeira para ações
        });

        // Configuração da entidade Department
        builder.Entity<Department>(e =>
        {
            e.HasKey(d => d.Id);
            e.HasMany(d => d.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId);
        });

        // Configuração da entidade Action
        builder.Entity<Action>(e =>
        {
            e.HasKey(a => a.Id);
            e.HasOne(a => a.User)
                .WithMany(u => u.Actions)
                .HasForeignKey(a => a.UserId); // Chave estrangeira para o usuário

            e.HasOne(a => a.Project)
                .WithMany(p => p.Actions)
                .HasForeignKey(a => a.ProjectId); // Chave estrangeira para o projeto
        });

        base.OnModelCreating(builder);
    }

}