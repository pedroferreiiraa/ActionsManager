using _5W2H.Core;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models;

public class ProjectViewModel
{
    public ProjectViewModel(int id, string title,  ProjectStatusEnum status)
    {
        Id = id;
        Title = title;
        
        
        Status = status;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    
    
    public static ProjectViewModel FromEntity(Project entity) 
        => new (entity.Id, entity.Title, entity.Status);
}