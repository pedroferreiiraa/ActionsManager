using _5W2H.Core;
using _5W2H.Core.Entities;
using _5W2H.Core.Enums;

namespace _5W2H.Application.Models;

public class ActionDetailsViewModel
{
    public ActionDetailsViewModel(int id, string title, string what, string why, string when, string where, string who, string how, decimal howMuch, ProjectStatusEnum status, string origin, string originDate, int projectId)
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
        ProjectId = projectId;
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
    public int ProjectId { get; private set; }
    
    public static ActionDetailsViewModel FromEntity(Acao acao) 
        => new (acao.Id, acao.Title, acao.What, acao.Why, acao.When, acao.Where, acao.Who, acao.How, acao.HowMuch, acao.Status, acao.Origin, acao.OriginDate, acao.ProjectId);
}