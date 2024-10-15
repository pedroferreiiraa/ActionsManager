using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Infrastructure.Repositories;

public class ActionRepository : IActionRepository
{
    private readonly WhoDbContext _context;
    
    public ActionRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Action>> GetAllAsync()
    {
        var projects = await _context.Actions.ToListAsync();
        return projects.Select(p => (Action)p).ToList(); // Supondo que Project herde de Action ou que você tenha uma conversão
    }

  

    public async Task<Action> GetByIdAsync(int id)
    {
        return await _context.Actions
            .SingleOrDefaultAsync(p => p.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task<int> AddAsync(Action action)
    {
        await _context.Actions.AddAsync(action);
        await _context.SaveChangesAsync(); 
        return action.Id;
    }
    

    public async Task Update(Action action)
    {
        _context.Actions.Update(action);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Projects.AnyAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var action =  _context.Actions.SingleOrDefault(p => p.Id == id);
        action.SetAsDeleted();
        await _context.SaveChangesAsync();
    }

    public async Task<Action> StartAsync(Action action)
    {
        var existingProjectAction = await _context.Actions.SingleOrDefaultAsync(p => p.Id == action.Id);
        if (existingProjectAction == null)
        {
            return null;
        }
        
        existingProjectAction.Start();
        
        await _context.SaveChangesAsync();
        
        return existingProjectAction;

        
    }
}