using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class DepartmentViewModel
{
    public DepartmentViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    public static DepartmentViewModel FromEntity(Department entity)
        => new(entity.Id, entity.Name);
}