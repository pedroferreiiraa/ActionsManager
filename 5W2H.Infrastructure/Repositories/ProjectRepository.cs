using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace _5W2H.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly WhoDbContext _context;
    
    public ProjectRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Project>> GetAllAsync()
    {
        var projects = await _context.Projects.ToListAsync();
        return projects.Select(p => (Project)p).ToList(); // Supondo que Project herde de Action ou que você tenha uma conversão
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        return await _context.Projects
            .SingleOrDefaultAsync(p => p.Id == id) ?? throw new InvalidOperationException();
    }
    
    public async Task<Project> GetByIdWithActionsAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.Actions) 
            .SingleOrDefaultAsync(p => p.Id == id); 
    }

    public async Task<int> AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync(); 
        return project.Id;
    }
    

    public async Task Update(Project project)
    {
        _context.Projects.Update(project);
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
        var project =  _context.Projects.SingleOrDefault(p => p.Id == id);
        project.SetAsDeleted();
        await _context.SaveChangesAsync();
    }

    public async Task<Project> StartAsync(Project project)
    {
        var existingProjectAction = await _context.Projects.SingleOrDefaultAsync(p => p.Id == project.Id);
        if (existingProjectAction == null)
        {
            return null;
        }
        
        existingProjectAction.Start();
        
        await _context.SaveChangesAsync();
        
        return existingProjectAction;

        
    }
    
}