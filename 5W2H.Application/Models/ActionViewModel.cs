using _5W2H.Core;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Models;

public class ActionViewModel
{
    public ActionViewModel(int id, string title,  ProjectStatusEnum status)
    {
        Id = id;
        Title = title;
        
        
        Status = status;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    
    
    public static ActionViewModel FromEntity(Action entity) 
        => new (entity.Id, entity.Title, entity.Status);
}