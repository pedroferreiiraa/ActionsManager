namespace _5W2H.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAll();
    Task<Project?> GetDetailsById(int id);
    Task<Project?> GetById(int id);
    
    Task<int> Add(Project project);
    Task Update(Project project);
    Task<bool> Exists(int id);
}