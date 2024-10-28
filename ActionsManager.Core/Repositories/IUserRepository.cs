using _5W2H.Core.Entities;

namespace _5W2H.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> GetUserByEmailAndPassword(string email, string passwordHash);
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
    Task Update(User user);
    Task SaveChangesAsync();
    
    Task<int> DeleteAsync(int id);
}