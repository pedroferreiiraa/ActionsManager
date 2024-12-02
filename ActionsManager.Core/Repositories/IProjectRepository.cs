using _5W2H.Core.Entities;
using Action = System.Action;

namespace _5W2H.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(int id);
    Task<Project> StartAsync(int id);
    Task<int> AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task<int> DeleteAsync(int id);
    Task<Project> GetByIdWithActionsAsync(int id);
    Task<List<Project>> GetProjectsByUserId(int userId);
    // Task<List<Project>> GetAllProjectsOfDepartment(int leaderId);
    Task<List<Project>> GetAllProjectsOfDepartment(int leaderId);
    Task SaveChangesAsync();
    
    IQueryable<Project> Query();
    
    
}