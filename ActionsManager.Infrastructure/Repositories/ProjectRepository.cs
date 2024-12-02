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
        return await _context.Projects
            .Include(p => p.Actions) // Inclui as ações relacionadas
            .ToListAsync();
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        return await _context.Projects
            .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }
    
    public async Task<Project> GetByIdWithActionsAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.Actions) // Inclui as ações relacionadas
            .SingleOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public async Task<int> AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync(); 
        return project.Id;
    }
    

    public async Task UpdateAsync(Project project)
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

    public IQueryable<Project> Query()
    {
        return _context.Projects.AsQueryable();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var project =  _context.Projects.SingleOrDefault(p => p.Id == id);
        
        if (project == null)
            throw new InvalidOperationException("Projeto não encontrado");
        
        project.SetAsDeleted();
        
        _context.Projects.Update(project);
        
        await _context.SaveChangesAsync();

        return project.Id;

    }

    public async Task<Project> StartAsync(int id)
    {
        var existingProject = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);

        if (existingProject == null)
        {
            return null;
        }
    
        existingProject.Start(); 
    
        await _context.SaveChangesAsync();
    
        return existingProject;
    }

    public async Task<List<Project>> GetProjectsByUserId(int userId)
    {
        return await _context.Projects
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Project>> GetAllProjectsOfDepartment(int leaderId)
{
    // Encontrar o departamento do líder
    var leaderDepartment = await _context.Users
        .Where(u => u.Id == leaderId)
        .Select(u => u.DepartmentId)
        .FirstOrDefaultAsync();

    if (leaderDepartment == null)
        return new List<Project>();

    // Buscar projetos de usuários do mesmo departamento
    return await _context.Projects
        .Include(p => p.User) // Incluir informações do usuário
        .Where(p => p.User.DepartmentId == leaderDepartment && !p.IsDeleted)
        .ToListAsync();
}

    // public Task<List<Project>> GetAllProjectsOfDepartment(int leaderId)
    // {
    //     throw new NotImplementedException();
    // }
}