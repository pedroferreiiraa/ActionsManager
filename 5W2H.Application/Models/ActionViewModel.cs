
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models;

public class ActionViewModel
{
    public ActionViewModel(int id, string title, string what, string why, string when, string where, string who, string how, decimal howMuch, ProjectStatusEnum status, int projectId, int userId, bool isDeleted)
    {
        Id = id;
        Title = title;
        What = what;
        Why = why;
        When = when;
        Where = where;
        Who = who;
        How = how;
        HowMuch = howMuch;
        Status = status;
        ProjectId = projectId;
        UserId = userId;
        IsDeleted = isDeleted;
    }


    public int Id { get; private set; }
    public string Title { get; private set; }
    
    public string What { get; private set; }
    public string Why { get; private set; }
    public string When { get; private set; }
    public string Where { get; private set; }
    public string Who { get; private set; }
    public string How { get; private set; }
    public decimal HowMuch { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public int ProjectId { get; private set; }
    public int UserId { get; private set; }
    
    public bool IsDeleted { get; private set; }
    
    
    public static ActionViewModel FromEntity(Acao entity) 
        => new (entity.Id, entity.Title, entity.What, entity.Why, entity.When, entity.Where, entity.Who, entity.How, entity.HowMuch, entity.Status, entity.ProjectId, entity.UserId, entity.IsDeleted);
}