using _5W2H.Core;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using Action = _5W2H.Core.Entities.Action;

namespace _5W2H.Application.Models;

public class ActionDetailsViewModel
{
    public ActionDetailsViewModel(int id, string title, string what, string why, string when, string where, string who, string how, decimal howMuch, ProjectStatusEnum status, string origin, string originDate)
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
    public string When { get; private set; }
    public string Where { get; private set; }
    public string Who { get; private set; }
    public string How { get; private set; }
    public decimal HowMuch { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    
    public string Origin { get; private set; }
    public string OriginDate { get; private set; }
    
    public static ActionDetailsViewModel FromEntity(Action action) 
        => new (action.Id, action.Title, action.What, action.Why, action.When, action.Where, action.Who, action.How, action.HowMuch, action.Status, action.Origin, action.OriginDate);
}