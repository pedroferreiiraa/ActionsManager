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
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return null;
        }
        
        return user;
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

    public async Task SaveChangesAsync(User user)
    {
        await _context.SaveChangesAsync();
    }
}