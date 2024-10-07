using System.Data.Common;
using _5W2H.Core;
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
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.HasMany(u => u.Projects)
                    .WithOne(us => us.User)
                    .HasForeignKey(us => us.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Project>(e =>
            {
                e.HasKey(e => e.Id);
                
                e.HasOne(p => p.User)
                    .WithMany(c => c.OwnedProjects)
                    .HasForeignKey(p => p.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                    
            });

        builder.Entity<Department>(e =>
        {
            e.HasKey(e => e.Id);
            
        });

    }
    
    
    
    
    
    
}