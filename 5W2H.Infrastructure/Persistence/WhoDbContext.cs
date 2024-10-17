// File: _5W2H.Infrastructure.Persistence/WhoDbContext.cs
using _5W2H.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace _5W2H.Infrastructure.Persistence
{
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
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);

                return new WhoDbContext(optionsBuilder.Options);
            }
        }

        public WhoDbContext(DbContextOptions<WhoDbContext> options) : base(options) { }

        // Definição dos DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Acao> Acoes { get; set; }  // Usar 'Acao' como definido na classe

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuração de User
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.HasOne(u => u.Department)
                    .WithMany(d => d.Users)
                    .HasForeignKey(u => u.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);  // Evita exclusão em cascata

                e.HasMany(u => u.Projects)
                    .WithOne()
                    .HasForeignKey(p => p.UserId);

                e.HasMany(u => u.Actions)
                    .WithOne(a => a.User)  // Adicionando o relacionamento correto
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração de Project
            builder.Entity<Project>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Actions)
                    .WithOne(a => a.Project)
                    .HasForeignKey(a => a.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);  // Excluir ações junto com o projeto
            });

            // Configuração de Department
            builder.Entity<Department>(e =>
            {
                e.HasKey(d => d.Id);

                e.HasMany(d => d.Users)
                    .WithOne(u => u.Department)
                    .HasForeignKey(u => u.DepartmentId);
            });

            // Configuração de Acao
            builder.Entity<Acao>(e =>
            {
                e.HasKey(a => a.Id);

                e.HasOne(a => a.User)
                    .WithMany(u => u.Actions)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);  // Impede exclusão em cascata

                e.HasOne(a => a.Project) // Relacionamento com Project
                    .WithMany(p => p.Actions) // Um projeto tem muitas ações
                    .HasForeignKey(a => a.ProjectId) // Chave estrangeira
                    .OnDelete(DeleteBehavior.Cascade); // Cascading delete
            });

            base.OnModelCreating(builder);
        }
    }
}
