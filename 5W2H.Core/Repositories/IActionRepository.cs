
using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface IActionRepository
{
    Task<List<Acao>> GetAllAsync();
    Task<Acao> GetByIdAsync(int id);
    Task<Acao> StartAsync(Acao acao);
    Task<int> AddAsync(Acao acao);
    Task Update(Acao acao);
    Task<bool> Exists(int id);
    
    Task SaveChangesAsync();
}