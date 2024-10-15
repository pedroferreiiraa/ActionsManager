using _5W2H.Core.Entities;
using _5W2H.Core.Repositories;
using _5W2H.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _5W2H.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly WhoDbContext _context;
    
    public DepartmentRepository(WhoDbContext context)
    {
        _context = context;
    }
    
    public async Task<Department> GetByIdAsync(int id)
    {
        return await _context.Departments
            .SingleOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException();
    }

    public async Task<int> AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department.Id;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        var departments = await _context.Departments.ToListAsync();
        return departments.ToList();
    }

    public async Task Update(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}