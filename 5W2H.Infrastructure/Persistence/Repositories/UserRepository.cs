using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WhoDbContext _context;
    
    public UserRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        
    }

    public Task<User> GetUserByEmailAndPassword(string email, string passwordHash)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        
    }

    public async Task Delete(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        user.SetAsDeleted();
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }


}