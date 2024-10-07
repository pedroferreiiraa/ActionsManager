using _5W2H.Core;
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
    
    public async Task<List<Project>> GetAll()
    {
       var projects = await _context.Projects.ToListAsync();

        return projects;
    }

    public async Task<Project?> GetDetailsById(int id)
    {
        var project = await _context.Projects
            .Include(p => p.User)
            .SingleOrDefaultAsync(p => p.Id == id); // Use SingleOrDefaultAsync aqui
    
        return project;
    }

    public async Task<Project?> GetById(int id)
    {
        return await _context.Projects
            .SingleOrDefaultAsync(p => p.Id == id);
    }


 

    public async Task<int> Add(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync(); // Use o método assíncrono
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

    public async Task Delete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);
        project.SetAsDeleted();
        await _context.SaveChangesAsync();
    }
}