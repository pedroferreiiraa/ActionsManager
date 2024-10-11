
using _5W2H.Core;
using _5W2H.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace _5W2H.Infrastructure.Persistence;

public class WhoDbContext : DbContext
{
    
    public class WhoDbContextFactory : IDesignTimeDbContextFactory<WhoDbContext>
    {
        public WhoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WhoDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=ferramentagestao;Username=admin;Password=135798");
            
            return new WhoDbContext(optionsBuilder.Options);
        }
    }

    public WhoDbContext(DbContextOptions<WhoDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }   
    public DbSet<Project> Projects { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configuração da entidade User
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id); // Primary key
        });

        // Configuração da entidade Project
        builder.Entity<Project>(e =>
        {
            e.HasKey(p => p.Id); // Primary key

            e.HasOne(p => p.User);
        });


       
        base.OnModelCreating(builder);
        
    }
    
}