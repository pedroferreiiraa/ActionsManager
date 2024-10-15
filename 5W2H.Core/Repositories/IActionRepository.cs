
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Core.Repositories;

public interface IActionRepository
{
    Task<List<Action>> GetAllAsync();
    Task<Action> GetByIdAsync(int id);
    Task<Action> StartAsync(Action action);
    Task<int> AddAsync(Action action);
    Task Update(Action action);
    Task<bool> Exists(int id);
    
    Task SaveChangesAsync();
}