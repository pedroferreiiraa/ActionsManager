using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(int id);
    Task<int> AddAsync(Department department);
    Task<List<Department>> GetAllAsync();
    Task Update(Department department);
    Task SaveChangesAsync();
}