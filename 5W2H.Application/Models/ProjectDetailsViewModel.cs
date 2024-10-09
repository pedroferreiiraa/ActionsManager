using _5W2H.Core;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models;

public class ProjectDetailsViewModel
{
    public ProjectDetailsViewModel(int id, string title, string what, string why, DateTime when, string where, string who, string how, decimal howMuch, ProjectStatusEnum status, string origin, DateTime originDate)
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
        Origin = origin;
        OriginDate = originDate;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string What { get; private set; }
    public string Why { get; private set; }
    public DateTime When { get; private set; }
    public string Where { get; private set; }
    public string Who { get; private set; }
    public string How { get; private set; }
    public decimal HowMuch { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    
    public string Origin { get; private set; }
    public DateTime OriginDate { get; private set; }
    
    public static ProjectDetailsViewModel FromEntity(Project project) 
        => new (project.Id, project.Title, project.What, project.Why, project.When, project.Where, project.Who, project.How, project.HowMuch, project.Status, project.Origin, project.OriginDate);
}