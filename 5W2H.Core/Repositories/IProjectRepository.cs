using _5W2H.Core.Entities;
using Action = System.Action;

namespace _5W2H.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(int id);
    Task<Project> StartAsync(Project project);
    Task<int> AddAsync(Project project);
    Task Update(Project project);
    Task<bool> Exists(int id);
    Task<Project> GetByIdWithActionsAsync(int id);
    
    Task SaveChangesAsync();
}