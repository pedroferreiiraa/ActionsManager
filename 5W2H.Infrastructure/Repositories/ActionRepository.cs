using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class ActionRepository : IActionRepository
{
    private readonly WhoDbContext _context;
    
    public ActionRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Acao>> GetAllAsync()
    {
        var projects = await _context.Acoes.ToListAsync();
        return projects.Select(p => (Acao)p).ToList(); // Supondo que Project herde de Action ou que você tenha uma conversão
    }

  

    public async Task<Acao> GetByIdAsync(int id)
    {
        return await _context.Acoes
            .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }

    public async Task<int> AddAsync(Acao acao)
    {
        await _context.Acoes.AddAsync(acao);
        await _context.SaveChangesAsync(); 
        return acao.Id;
    }
    

    public async Task Update(Acao acao)
    {
        _context.Acoes.Update(acao);
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

    public async Task<int> DeleteAsync(int id)
    {
        var action = await _context.Acoes.SingleOrDefaultAsync(p => p.Id == id);
    
        if (action == null)
            throw new InvalidOperationException("Ação não encontrado");

        action.SetAsDeleted();
    
        _context.Acoes.Update(action); 
    
        await _context.SaveChangesAsync();
    
        return action.Id;  
    }

    public async Task<Acao> StartAsync(Acao acao)
    {
        var existingProjectAction = await _context.Acoes.SingleOrDefaultAsync(p => p.Id == acao.Id);
        if (existingProjectAction == null)
        {
            return null;
        }
        
        existingProjectAction.Start();
        
        await _context.SaveChangesAsync();
        
        return existingProjectAction;

        
    }
}