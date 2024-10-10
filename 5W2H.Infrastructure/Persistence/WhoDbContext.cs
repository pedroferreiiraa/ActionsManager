
using _5W2H.Core;
using _5W2H.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _5W2H.Infrastructure.Persistence;

public class WhoDbContext : DbContext
{
    public class WhoDbContextFactory : IDesignTimeDbContextFactory<WhoDbContext>
    {
        public WhoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WhoDbContext>();
            optionsBuilder.UseInMemoryDatabase("WhoDbContext");
            
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
        builder
            .Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

            });

        builder
            .Entity<Project>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasOne(p => p.User);

            });

       
        base.OnModelCreating(builder);
        
    }
    
}